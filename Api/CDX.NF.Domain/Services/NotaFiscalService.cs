using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Services.Interface;
using CDX.NF.Domain.Repository.Interface;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models.To.Extensoes;
using System;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Models.Enum;
using CDX.NF.Core.Infraestrutura.Enum;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

namespace CDX.NF.Domain.Services
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly IUsuarioRepository _usuarioRepositoy;
        private readonly IRequisicaoRepository _requisicaoRepository;
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly IParametrosRepository _parametroRepository;
        private readonly ICidadeNfeRepository _cidadeNfeRepository;
        private readonly INotaFiscalAutorizadaRepository _notaFiscalAutorizadaRepository;
        private readonly INotaFiscalSolicitadaRepository _notaFiscalSolicitadaRepository;
        private readonly Contexto _db;
        private X509Certificate2 _x509Certificate2;

        public NotaFiscalService(IUsuarioRepository usuarioRepositoy, IRequisicaoRepository requisicaoRepository, INotaFiscalRepository notaFiscalRepository, IParametrosRepository parametroRepository, ICidadeNfeRepository cidadeNfeRepository, INotaFiscalAutorizadaRepository notaFiscalAutorizadaRepository, Contexto context
            , INotaFiscalSolicitadaRepository notaFiscalSolicitadaRepository)
        {
            _usuarioRepositoy = usuarioRepositoy;
            _requisicaoRepository = requisicaoRepository;
            _notaFiscalRepository = notaFiscalRepository;
            _parametroRepository = parametroRepository;
            _cidadeNfeRepository = cidadeNfeRepository;
            _notaFiscalAutorizadaRepository = notaFiscalAutorizadaRepository;
            _notaFiscalSolicitadaRepository = notaFiscalSolicitadaRepository;
            _db = context;
        }

        /* Async */
        public async Task<Retorno<RetornoServicoTo>> AutorizarAsync(AutorizacaoNfeTo autorizacaoNfeTo)
        {
            var retorno = new Retorno<RetornoServicoTo>() { Status = ResultadoOperacao.Sucesso };

            #region ValidaInicioProcesso

            retorno = await ValidaInicioProcesso(autorizacaoNfeTo.Autenticacao.Usuario, autorizacaoNfeTo.Autenticacao.Senha, autorizacaoNfeTo.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Codigo_municipio, autorizacaoNfeTo.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Cnpj);

            if (retorno.Status != ResultadoOperacao.Sucesso)
            {
                retorno.Status = ResultadoOperacao.Falha;
                return retorno;
            }

            #endregion

            var usuario = await _usuarioRepositoy.ObterTodosAsync(autorizacaoNfeTo.Autenticacao.Usuario, autorizacaoNfeTo.Autenticacao.Senha);
            var cidade = await _cidadeNfeRepository.ObterTodosAsync(autorizacaoNfeTo.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Codigo_municipio, string.Empty);
            var parametros = await _parametroRepository.ObterTodosAsync(autorizacaoNfeTo.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Codigo_municipio, autorizacaoNfeTo.Nfe.CapaAutorizacaoNfse.Autorizar.Prestador.Cnpj);

            if (!parametros.UtilizaCertificado)
            {
                _x509Certificate2 = null;
            }

            /* Gera nova sequencia para referenciar nota fiscal */
            var referencia = await _db.GetReferenciaAsync();
            autorizacaoNfeTo.Nfe.CapaAutorizacaoNfse.Identificador_nota = referencia;

            /* Registra a requisição */
            var req = new Requisicao
            {
                TipoOperacao = TipoOperacao.Autorizacao,
                Referencia = referencia,
                Etapa = EtapaRequisicao.RecebidoPedido,
                Status = StatusOperacao.Indefinido,
                Cidade = cidade,
                ValorNota = autorizacaoNfeTo.Nfe.CapaAutorizacaoNfse.Autorizar.Servico.Valor_servicos,
                UsuarioId = usuario.Id,
                Prestador = parametros.Prestador,
                ServicoWsSoap = parametros.ServicoWsSoap
            };

            int requisicaoId = await _requisicaoRepository.InserirAsync(req);

            try
            {
                NotaFiscalSolicitada objNotaFiscalSolicitada = autorizacaoNfeTo.ToNotaFiscalSolicitada(usuario.Id);
                var nfeSlicitadaId = await _notaFiscalSolicitadaRepository.InserirAsync(objNotaFiscalSolicitada);

                Retorno<RetornoWsTo> retornoServicoWs = null;

                /* Autorizar a emissão da nfe */
                if (parametros.ServicoWsSoap.Codigo == (int)WsSoapServices.MobLink)
                {
                    WsMobLinkService.CapaAutorizacaoNfse objAutorizar = autorizacaoNfeTo.ToWsAutorizarService(WsSoapServices.MobLink);

                    MobLinkService mobLinkService = new MobLinkService(_x509Certificate2);

                    retornoServicoWs = await mobLinkService.AutorizarAsync(objAutorizar);

                    if (retornoServicoWs.Status != ResultadoOperacao.Sucesso)
                    {
                        var requisicaoErro = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                        requisicaoErro.Status = StatusOperacao.Erro;
                        requisicaoErro.Erro = retornoServicoWs.Mensagens.Count > 0 ? retornoServicoWs.Mensagens[0].Mensagem : string.Empty;
                        requisicaoErro.Etapa = retornoServicoWs.Objeto != null ? retornoServicoWs.Objeto.Etapa : EtapaRequisicao.PendenteEnvio;
                        _requisicaoRepository.Alterar(requisicaoErro);

                        retorno.Mensagens.AddRange(retornoServicoWs.Mensagens);
                        retorno.Status = ResultadoOperacao.Falha;
                        return retorno;
                    }

                    var reqAuteracao = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                    reqAuteracao.Status = retornoServicoWs.Objeto.RetornoServicoTo != null ? getStatusRequisicao(retornoServicoWs.Objeto.RetornoServicoTo.Status) : StatusOperacao.Indefinido;
                    reqAuteracao.Etapa = retornoServicoWs.Objeto.Etapa;
                    _requisicaoRepository.Alterar(reqAuteracao);
                }
                else
                {
                    retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "CDXNF0005", Mensagem = string.Format("Não há um serviço soap cadastrado para a cidade de {0} .", cidade.Descricao) });
                    retorno.Status = ResultadoOperacao.Falha;
                    return retorno;
                }

                Requisicao requisicaoAlteracao = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                requisicaoAlteracao.Etapa = EtapaRequisicao.Processada;
                requisicaoAlteracao.TempoExecucao = retornoServicoWs.Objeto.TempoExecucao;
                requisicaoAlteracao.Observacao = string.Format("{0} {1} {2}", retornoServicoWs.Objeto.Observacao, retornoServicoWs.Objeto.RetornoServicoTo != null ? retornoServicoWs.Objeto.RetornoServicoTo.Status : string.Empty, retornoServicoWs.Objeto.RetornoServicoTo != null ? retornoServicoWs.Objeto.RetornoServicoTo.Mensagem : string.Empty);
                _requisicaoRepository.Alterar(requisicaoAlteracao);

                retorno.Objeto = retornoServicoWs.Objeto.RetornoServicoTo;
            }
            catch (Exception ex)
            {
                var mensagem = string.Format("O Não foi possível soliciatar a autorização da nota fiscal de referência {0}.", referencia);
                var requisicaoex = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                requisicaoex.Erro = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                requisicaoex.Status = StatusOperacao.Erro;
                requisicaoex.Observacao = mensagem;
                _requisicaoRepository.Alterar(requisicaoex);

                retorno.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Solicitação de Nota", Identificador = "CDXNF0001", Mensagem = mensagem });
                retorno.Status = ResultadoOperacao.Falha;
            }

            return retorno;
        }

        public async Task<Retorno<NotaFiscalRetornoTo>> ConsultarAsync(ConsultaNfeTo consultaNfeTo)
        {
            var notaFiscalRetornoTo = new NotaFiscalRetornoTo();
            var retorno = new Retorno<NotaFiscalRetornoTo>() { Status = ResultadoOperacao.Sucesso };

            #region ValidaInicioProcesso

            Retorno<RetornoServicoTo> retornoValidacao = await ValidaInicioProcesso(consultaNfeTo.Autenticacao.Usuario, consultaNfeTo.Autenticacao.Senha, consultaNfeTo.CodigoMunicipio, consultaNfeTo.CnpjPrestador);

            if (retornoValidacao.Status != ResultadoOperacao.Sucesso)
            {
                retorno.Status = ResultadoOperacao.Falha;
                return retorno;
            }

            #endregion

            var usuario = await _usuarioRepositoy.ObterTodosAsync(consultaNfeTo.Autenticacao.Usuario, consultaNfeTo.Autenticacao.Senha);
            var cidade = await _cidadeNfeRepository.ObterTodosAsync(consultaNfeTo.CodigoMunicipio, string.Empty);
            var parametros = await _parametroRepository.ObterTodosAsync(consultaNfeTo.CodigoMunicipio, consultaNfeTo.CnpjPrestador);

            /* Verifica se nota existe na base */
            var notaAutorizada = await _notaFiscalAutorizadaRepository.ObterTodosAsync(string.Empty, consultaNfeTo.Referencia);

            if (notaAutorizada != null)
            {
                /* Retorno do metodo */
                notaFiscalRetornoTo.Status = string.Format("Nota Fiscal obtida da Base {0}", notaAutorizada.Numero);
                if (Convert.ToInt32(consultaNfeTo.FormaRetorno) == (int)TipoRetorno.Url)
                    notaFiscalRetornoTo.Url = notaAutorizada.UrlPrefeitura;
                else
                    notaFiscalRetornoTo.Imagem = Convert.ToBase64String(notaAutorizada.ImagemNfe);
                notaFiscalRetornoTo.Numero = notaAutorizada.Numero;

                var objRequisicao = new Requisicao()
                {
                    Etapa = EtapaRequisicao.RecebidoPedido,
                    TempoExecucao = 0,
                    Observacao = string.Format("Nota Fiscal obtida da Base {0}", notaAutorizada.Numero),
                    Cidade = cidade,
                    UsuarioId = usuario.Id,
                    Prestador = parametros.Prestador,
                    ServicoWsSoap = parametros.ServicoWsSoap,
                    Referencia = Convert.ToInt32(consultaNfeTo.Referencia),
                    TipoOperacao = TipoOperacao.Consulta,
                    NotaFiscalAutorizadaId = notaAutorizada.Id
                };
                await _requisicaoRepository.InserirAsync(objRequisicao);

                retorno.Objeto = notaFiscalRetornoTo;
                retorno.Status = ResultadoOperacao.Sucesso;
                return retorno;
            }

            ServicoWsSoap servicoWsSoap = new ServicoWsSoap();

            /* Obtem cliente da requisição de autorização*/
            Requisicao requisicaoCliente = null;
            requisicaoCliente = await _requisicaoRepository.ObterTodosPorStatusAsync(Convert.ToInt32(consultaNfeTo.Referencia), TipoOperacao.Autorizacao, EtapaRequisicao.Processada, StatusOperacao.OperacaoEfetivada);

            if (requisicaoCliente == null)
                requisicaoCliente = await _requisicaoRepository.ObterTodosPorStatusAsync(Convert.ToInt32(consultaNfeTo.Referencia), TipoOperacao.Autorizacao, EtapaRequisicao.Processada, StatusOperacao.ProcessandoOperacao);

            if (requisicaoCliente != null)
            {
                /* Cliente pelo qual foi realizada o pedido de autorização (Autorizar a emissão de uma nfe)*/
                servicoWsSoap = requisicaoCliente.ServicoWsSoap;
            }
            else
            {
                servicoWsSoap = parametros.ServicoWsSoap;
            }

            /* Registra a requisição */
            var requisicao = new Requisicao
            {
                TipoOperacao = TipoOperacao.Consulta,
                Referencia = Convert.ToInt32(consultaNfeTo.Referencia),
                Etapa = EtapaRequisicao.RecebidoPedido,
                Status = StatusOperacao.Indefinido,
                Cidade = cidade,
                UsuarioId = usuario.Id,
                Prestador = parametros.Prestador,
                ServicoWsSoap = parametros.ServicoWsSoap
            };

            int requisicaoId = await _requisicaoRepository.InserirAsync(requisicao);

            try
            {
                Retorno<RetornoWsTo> retornoServicoWs = null;

                /* Emite nota fiscal */
                if (servicoWsSoap.Codigo == (int)WsSoapServices.MobLink)
                {
                    WsMobLinkService.Consultar objConsultar = consultaNfeTo.ToWsConsultarService(WsSoapServices.MobLink);
                    MobLinkService mobLinkService = new MobLinkService(_x509Certificate2);
                    retornoServicoWs = await mobLinkService.ConsultarAsync(objConsultar);

                    if (retornoServicoWs.Status != ResultadoOperacao.Sucesso)
                    {
                        var requisicaoErro = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                        requisicaoErro.Status = StatusOperacao.Erro;
                        requisicaoErro.Erro = retornoServicoWs.Mensagens.Count > 0 ? retornoServicoWs.Mensagens[0].Mensagem : string.Empty;
                        requisicaoErro.Etapa = retornoServicoWs.Objeto != null ? retornoServicoWs.Objeto.Etapa : EtapaRequisicao.PendenteEnvio;
                        _requisicaoRepository.Alterar(requisicaoErro);

                        retorno.Mensagens.AddRange(retornoServicoWs.Mensagens);
                        retorno.Status = retornoServicoWs.Status;
                        return retorno;
                    }

                    var reqNovaEtapa = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                    reqNovaEtapa.Status = retornoServicoWs.Objeto.DeserializedNfe != null ? getStatusRequisicao(retornoServicoWs.Objeto.DeserializedNfe.Status) : StatusOperacao.Indefinido;
                    reqNovaEtapa.Observacao = retornoServicoWs.Objeto.DeserializedNfe != null ? retornoServicoWs.Objeto.DeserializedNfe.Status : string.Empty;
                    reqNovaEtapa.Etapa = retornoServicoWs.Objeto.Etapa;
                    _requisicaoRepository.Alterar(reqNovaEtapa);
                }
                else
                {
                    retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "CDXNF0005", Mensagem = string.Format("Não há um serviço soap cadastrado para a cidade de {0} .", cidade.Descricao) });
                    retorno.Status = ResultadoOperacao.Falha;
                    return retorno;
                }

                if(getStatusRequisicao(retornoServicoWs.Objeto.DeserializedNfe.Status) == StatusOperacao.ProcessandoOperacao || getStatusRequisicao(retornoServicoWs.Objeto.DeserializedNfe.Status) != StatusOperacao.OperacaoEfetivada)
                {
                    notaFiscalRetornoTo.Status = retornoServicoWs.Objeto.DeserializedNfe.Status;
                    retorno.Objeto = notaFiscalRetornoTo;
                    retorno.Status = ResultadoOperacao.Alerta;
                    return retorno;
                }

                /* Obtendo a data de emissão*/
                var numsegs = Convert.ToInt32(retornoServicoWs.Objeto.DeserializedNfe.data_emissao.Replace("/Date(", "").Replace(")/", "").Substring(0, 10));
                System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
                var dataEmissao = dtDateTime.AddSeconds(numsegs).ToLocalTime();

                var requisicaoAlteracao = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                requisicaoAlteracao.Etapa = EtapaRequisicao.Processada;
                requisicaoAlteracao.TempoExecucao = retornoServicoWs.Objeto.TempoExecucao;
                requisicaoAlteracao.Observacao = string.Format("{0} {1} {2}", retornoServicoWs.Objeto.Observacao, retornoServicoWs.Objeto.DeserializedNfe != null ? retornoServicoWs.Objeto.DeserializedNfe.Status : string.Empty, retornoServicoWs.Objeto.DeserializedNfe != null ? retornoServicoWs.Objeto.DeserializedNfe.Numero : string.Empty);
                _requisicaoRepository.Alterar(requisicaoAlteracao);

                /* Grava dados da nota fiscal emitida */
                NotaFiscalAutorizada notaFiscalAutorizada = new NotaFiscalAutorizada()
                {
                    UsuarioId = usuario.Id,
                    Referencia = retornoServicoWs.Objeto.DeserializedNfe.Ref,
                    Status = retornoServicoWs.Objeto.DeserializedNfe.Status,
                    Numero = retornoServicoWs.Objeto.DeserializedNfe.Numero,
                    CodigoVerificacao = retornoServicoWs.Objeto.DeserializedNfe.Codigo_verificacao,
                    DataEmissao = dataEmissao,
                    UrlPrefeitura = retornoServicoWs.Objeto.DeserializedNfe.Url,
                    CaminhoNfe = retornoServicoWs.Objeto.DeserializedNfe.caminho_xml_nota_fiscal,
                    ImagemNfe = retornoServicoWs.Objeto.DeserializedNfe.Retorno_nota,
                    ServicoWsSoap = parametros.ServicoWsSoap,
                    Prestador = parametros.Prestador
                };

                var notaFiscalAutorizadaId = await _notaFiscalAutorizadaRepository.InserirAsync(notaFiscalAutorizada);

                /* Vincular a nota fiscal autorizada a requisição que solicitou a autorização */
                requisicaoCliente.NotaFiscalAutorizadaId = notaFiscalAutorizadaId;
                requisicaoCliente.Observacao = retornoServicoWs.Objeto.DeserializedNfe != null ? retornoServicoWs.Objeto.DeserializedNfe.Status : string.Empty;
                _requisicaoRepository.Alterar(requisicaoAlteracao);

                /* Retorno do metodo */
                notaFiscalRetornoTo.Status = retornoServicoWs.Objeto.DeserializedNfe.Status;

                if (Convert.ToInt32(consultaNfeTo.FormaRetorno) == (int)TipoRetorno.Url)
                    notaFiscalRetornoTo.Url = retornoServicoWs.Objeto.DeserializedNfe.Url;
                else
                    notaFiscalRetornoTo.Imagem = Convert.ToBase64String(retornoServicoWs.Objeto.DeserializedNfe.Retorno_nota);
                notaFiscalRetornoTo.Numero = retornoServicoWs.Objeto.DeserializedNfe.Numero;

                retorno.Status = ResultadoOperacao.Sucesso;
                retorno.Objeto = notaFiscalRetornoTo;
            }
            catch (Exception ex)
            {
                var mensagem = string.Format("Não foi possível obter a nota fiscal de referência {0}.", consultaNfeTo.Referencia);
                var requisicaoex = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                requisicaoex.Erro = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                requisicaoex.Status = StatusOperacao.Erro;
                requisicaoex.Observacao = mensagem;
                _requisicaoRepository.Alterar(requisicaoex);

                retorno.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Consulta de Nota", Identificador = "CDXNF0001", Mensagem = mensagem });
                retorno.Status = ResultadoOperacao.Falha;
            }

            return retorno;
        }

        public async Task<Retorno<RetornoServicoTo>> CancelarAsync(CancelamentoNfeTo cancelamentoNfeTo)
        {
            var notaFiscalRetornoTo = new RetornoServicoTo();
            var retorno = new Retorno<RetornoServicoTo>() { Status = ResultadoOperacao.Sucesso };

            #region ValidaInicioProcesso

            retorno = await ValidaInicioProcesso(cancelamentoNfeTo.Autenticacao.Usuario, cancelamentoNfeTo.Autenticacao.Senha, cancelamentoNfeTo.CodigoMunicipio, cancelamentoNfeTo.CnpjPrestador);

            if (retorno.Status != ResultadoOperacao.Sucesso)
            {
                retorno.Status = ResultadoOperacao.Falha;
                return retorno;
            }

            #endregion

            var usuario = await _usuarioRepositoy.ObterTodosAsync(cancelamentoNfeTo.Autenticacao.Usuario, cancelamentoNfeTo.Autenticacao.Senha);
            var cidade = await _cidadeNfeRepository.ObterTodosAsync(cancelamentoNfeTo.CodigoMunicipio, string.Empty);
            var parametros = await _parametroRepository.ObterTodosAsync(cancelamentoNfeTo.CodigoMunicipio, cancelamentoNfeTo.CnpjPrestador);

            /* Registra a requisição */
            var requisicao = new Requisicao
            {
                TipoOperacao = TipoOperacao.Cancelamento,
                Referencia = Convert.ToInt32(cancelamentoNfeTo.Referencia),
                Etapa = EtapaRequisicao.RecebidoPedido,
                Status = StatusOperacao.Indefinido,
                Cidade = cidade,
                UsuarioId = usuario.Id,
                Prestador = parametros.Prestador,
                ServicoWsSoap = parametros.ServicoWsSoap
            };

            var requisicaoId = await _requisicaoRepository.InserirAsync(requisicao);

            ServicoWsSoap servicoWsSoap = new ServicoWsSoap();

            /* Obtem cliente da requisição de autorização*/
            Requisicao requisicaoCliente = null;
            requisicaoCliente = await _requisicaoRepository.ObterTodosPorStatusAsync(Convert.ToInt32(cancelamentoNfeTo.Referencia), TipoOperacao.Autorizacao, EtapaRequisicao.Processada, StatusOperacao.OperacaoEfetivada);
            if (requisicaoCliente == null)
                requisicaoCliente = await _requisicaoRepository.ObterTodosPorStatusAsync(Convert.ToInt32(cancelamentoNfeTo.Referencia), TipoOperacao.Autorizacao, EtapaRequisicao.Processada, StatusOperacao.ProcessandoOperacao);
            if (requisicaoCliente != null)
            {
                /* Cliente pelo qual foi realizada o pedido de autorização */
                servicoWsSoap = requisicaoCliente.ServicoWsSoap;
            }
            else
            {
                servicoWsSoap = parametros.ServicoWsSoap;
            }

            Retorno<RetornoWsTo> retornoServicoWs = null;

            try
            {
                /* Cancela nota fiscal */
                if (servicoWsSoap.Codigo == (int)WsSoapServices.MobLink)
                {
                    WsMobLinkService.Cancelar objCancelar = cancelamentoNfeTo.ToWsCancelarService(WsSoapServices.MobLink);
                    MobLinkService mobLinkService = new MobLinkService(_x509Certificate2);
                    retornoServicoWs = await mobLinkService.CancelarAsync(objCancelar);

                    if (retornoServicoWs.Status != ResultadoOperacao.Sucesso)
                    {
                        var requisicaoErro = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                        requisicaoErro.Status = StatusOperacao.Erro;
                        requisicaoErro.Erro = retornoServicoWs.Mensagens.Count > 0 ? retornoServicoWs.Mensagens[0].Mensagem : string.Empty;
                        requisicaoErro.Etapa = retornoServicoWs.Objeto != null ? retornoServicoWs.Objeto.Etapa : EtapaRequisicao.PendenteEnvio;
                        _requisicaoRepository.Alterar(requisicaoErro);

                        retorno.Mensagens.AddRange(retornoServicoWs.Mensagens);
                        retorno.Status = retornoServicoWs.Status;
                        return retorno;
                    }

                    var reqNovaEtapa = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                    reqNovaEtapa.Etapa = retornoServicoWs.Objeto.Etapa;
                    _requisicaoRepository.Alterar(reqNovaEtapa);
                }
                else
                {
                    retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "CDXNF0005", Mensagem = string.Format("Não há um serviço soap cadastrado para a cidade de {0} .", cidade.Descricao) });
                    retorno.Status = ResultadoOperacao.Falha;
                    return retorno;
                }

                var requisicaoAlteracao = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                requisicaoAlteracao.Etapa = EtapaRequisicao.Processada;
                requisicaoAlteracao.TempoExecucao = retornoServicoWs.Objeto.TempoExecucao;
                requisicaoAlteracao.Observacao = retornoServicoWs.Objeto.Observacao;
                _requisicaoRepository.Alterar(requisicaoAlteracao);

                notaFiscalRetornoTo.Status = retornoServicoWs.Objeto.RetornoServicoTo.Status;
                notaFiscalRetornoTo.Mensagem = retornoServicoWs.Objeto.RetornoServicoTo.Mensagem;

                retorno.Objeto = notaFiscalRetornoTo;
            }
            catch (Exception ex)
            {
                var mensagem = string.Format("O Não foi possível cancelar a nota fiscal de referência {0}.", cancelamentoNfeTo.Referencia);
                var requisicaoex = await _requisicaoRepository.ObterPorIdAsync(requisicaoId);
                requisicaoex.Erro = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                requisicaoex.Status = StatusOperacao.Erro;
                requisicaoex.Observacao = mensagem;
                _requisicaoRepository.Alterar(requisicaoex);

                retorno.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Cancelamento de Nota", Identificador = "CDXNF0001", Mensagem = mensagem });
                retorno.Status = ResultadoOperacao.Falha;
            }

            return retorno;
        }

        private StatusOperacao getStatusRequisicao(string status)
        {
            var statusResult = new StatusOperacao();

            switch (status)
            {
                case "erro":
                    statusResult = StatusOperacao.Erro;
                    break;
                case "processando_autorizacao":
                    statusResult = StatusOperacao.ProcessandoOperacao;
                    break;
                case "autorizado":
                    statusResult = StatusOperacao.OperacaoEfetivada;
                    break;
                case "nfe_autorizada":
                    statusResult = StatusOperacao.EfetivadaAnteriormente;
                    break;
                case "nao_encontrado":
                    statusResult = StatusOperacao.InformacaoNaoEncontrada;
                    break;
                case "em_processamento":
                    statusResult = StatusOperacao.ProcessandoOperacao;
                    break;
                case "rejeitado":
                    statusResult = StatusOperacao.RequisicaoRejeitada;
                    break;
                case "requisicao_invalida":
                    statusResult = StatusOperacao.RequisicaoInvalida;
                    break;
                case "empresa_nao_habilitada":
                    statusResult = StatusOperacao.EmpresaNaoHabilitada;
                    break;
                case "nfe_cancelada":
                    statusResult = StatusOperacao.NfeCancelada;
                    break;
                case "permissao_negada":
                    statusResult = StatusOperacao.PermissaoNegada;
                    break;
                case "nfe_nao_autorizada":
                    statusResult = StatusOperacao.NfeNaoAutorizada;
                    break;
                default:
                    statusResult = StatusOperacao.Indefinido;
                    break;
            }

            return statusResult;
        }

        private async Task<Retorno<RetornoServicoTo>> ValidaInicioProcesso(string strUsuario, string strSenha, string strCodigoMuncipio, string strCnpjPrestador)
        {
            var retorno = new Retorno<RetornoServicoTo>() { Status = ResultadoOperacao.Sucesso };

            var usuario = await _usuarioRepositoy.ObterTodosAsync(strUsuario, strSenha);

            /* Valida a permissão do usuário para emitir a nota fiscal */
            if (usuario == null)
            {
                retorno.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Permissão de Usuário", Identificador = "CDXNF0001", Mensagem = string.Format("O Usuário {0} não está autorizado a emitir nfe.", strUsuario) });
                retorno.Status = ResultadoOperacao.Falha;
            }

            var cidade = await _cidadeNfeRepository.ObterTodosAsync(strCodigoMuncipio, string.Empty);

            if (cidade == null)
            {
                retorno.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Cadastro de Cidade", Identificador = "CDXNF0002", Mensagem = string.Format("Não foi possível localizar o municipo {0}", strCodigoMuncipio) });
                retorno.Status = ResultadoOperacao.Falha;
            }

            /* Obtem os parametros de configuração por cidade e prestador*/
            var parametros = await _parametroRepository.ObterTodosAsync(strCodigoMuncipio, strCnpjPrestador);

            if (parametros == null || string.IsNullOrEmpty(parametros.Certificado))
            {
                retorno.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Cadastro de Parametros", Identificador = "CDXNF0003", Mensagem = string.Format("Não foi possível localizar os parametros para o municipo {0} e prestador {1}.", strCodigoMuncipio, strCnpjPrestador) });
                retorno.Status = ResultadoOperacao.Falha;
            }
            else
            {
                if (parametros.UtilizaCertificado)
                {
                    X509Store stores = new X509Store(StoreName.My, StoreLocation.LocalMachine);
                    stores.Open(OpenFlags.ReadOnly);

                    X509Certificate2Collection certificados = stores.Certificates;

                    X509Certificate2Collection certificadosEncontrados = certificados.Find(
                        X509FindType.FindBySerialNumber,
                        parametros.Certificado,
                        false);

                    if (certificadosEncontrados.Count > 0)
                    {
                        _x509Certificate2 = certificadosEncontrados[0];
                    }
                    else
                    {
                        retorno.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Certificado Digital", Identificador = "CDXNF0005", Mensagem = string.Format("Não foi possível localizar o certificado digital para o cnpj {0}.", strCnpjPrestador) });
                        retorno.Status = ResultadoOperacao.Falha;
                    }

                    stores.Close();
                }
            }   

            return retorno;
        }
    }
}
