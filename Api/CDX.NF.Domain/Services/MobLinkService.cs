using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services
{
    public class MobLinkService : IMobLinkService
    {
        private readonly X509Certificate2 _x509Certificate2;

        public MobLinkService(X509Certificate2 x509Certificate2)
        {
            _x509Certificate2 = x509Certificate2;
        }

        public async Task<Retorno<RetornoWsTo>> AutorizarAsync(WsMobLinkService.CapaAutorizacaoNfse objAutorizar)
        {
            var retorno = new Retorno<RetornoWsTo>() { Status = ResultadoOperacao.Sucesso };
            RetornoWsTo retornoWsTo = new RetornoWsTo();

            var stopwatch = new Stopwatch();

            /* Autoriza a emissão de uma Nfe */
            try
            {
                WsMobLinkService.WSnfseSoapClient clienteWs = new WsMobLinkService.WSnfseSoapClient(WsMobLinkService.WSnfseSoapClient.EndpointConfiguration.WSnfseSoap);

                if (_x509Certificate2 != null)
                {
                    clienteWs.ClientCredentials.ServiceCertificate.DefaultCertificate = _x509Certificate2;
                }

                retornoWsTo.Etapa = Models.Enum.EtapaRequisicao.PendenteEnvio;

                stopwatch.Start();
                var retornoWs = await clienteWs.AutorizarAsync(objAutorizar);
                stopwatch.Stop();

                RetornoServicoTmpTo retornoServicoToTmp = JsonConvert.DeserializeObject<RetornoServicoTmpTo>(retornoWs);

                RetornoServicoTo retornoServicoTo = new RetornoServicoTo()
                {
                    Codigo_municipo = objAutorizar.autorizar.prestador.codigo_municipio,
                    Ref = retornoServicoToTmp.Ref != 0 ? retornoServicoToTmp.Ref : objAutorizar.identificador_nota,
                    Cnpj_prestador = !string.IsNullOrEmpty(retornoServicoToTmp.Cnpj_prestador) ? retornoServicoToTmp.Cnpj_prestador : objAutorizar.autorizar.prestador.cnpj,
                    Status = !string.IsNullOrEmpty(retornoServicoToTmp.Status) ? retornoServicoToTmp.Status : retornoServicoToTmp.Codigo,
                    Mensagem = retornoServicoToTmp.Mensagem
                };

                retornoWsTo.Etapa = Models.Enum.EtapaRequisicao.ComRetorno;
                retornoWsTo.TempoExecucao = stopwatch.Elapsed.Seconds;
                retornoWsTo.RetornoServicoTo = retornoServicoTo;
                retorno.Objeto = retornoWsTo;
            }
            catch (Exception ex)
            {
                retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "EXCEPTION", Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "CDXNF0002", Mensagem = string.Format("Ocorreu um erro ao tentar autorizar a nota fiscal de referência {0}.", objAutorizar.identificador_nota.ToString()) });
                retornoWsTo.Observacao = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                retorno.Status = ResultadoOperacao.Falha;
                return retorno;
            }

            return retorno;
        }

        public async Task<Retorno<RetornoWsTo>> ConsultarAsync(WsMobLinkService.Consultar objConsultar)
        {
            var retorno = new Retorno<RetornoWsTo>() { Status = ResultadoOperacao.Sucesso };
            RetornoWsTo retornoWsTo = new RetornoWsTo();

            var stopwatch = new Stopwatch();

            /* Consulta nota autorizada */
            try
            {
                retornoWsTo.Etapa = Models.Enum.EtapaRequisicao.PendenteEnvio;

                WsMobLinkService.WSnfseSoapClient cliente = new WsMobLinkService.WSnfseSoapClient(WsMobLinkService.WSnfseSoapClient.EndpointConfiguration.WSnfseSoap);

                stopwatch.Start();
                var resultConsulta = await cliente.ConsultarAsync(objConsultar);
                stopwatch.Stop();

                NotaFiscalAutorizadaTmpTo deserializedNfe = JsonConvert.DeserializeObject<NotaFiscalAutorizadaTmpTo>(resultConsulta);

                NotaFiscalAutorizadaTo notaFiscalAutorizadaTo = new NotaFiscalAutorizadaTo()
                {
                    Ref = deserializedNfe.Ref,
                    Cnpj_prestador = deserializedNfe.Cnpj_prestador,
                    Status = !string.IsNullOrEmpty(deserializedNfe.Status) ? deserializedNfe.Status : deserializedNfe.Codigo,
                    Numero = deserializedNfe.Numero,
                    Codigo_verificacao = deserializedNfe.Codigo_verificacao,
                    data_emissao = deserializedNfe.data_emissao,
                    Url = deserializedNfe.Url,
                    caminho_xml_nota_fiscal = deserializedNfe.caminho_xml_nota_fiscal,
                    Retorno_nota = deserializedNfe.Retorno_nota,
                    Mensagem = deserializedNfe.Mensagem
                };

                retornoWsTo.Etapa = Models.Enum.EtapaRequisicao.ComRetorno;
                retornoWsTo.TempoExecucao = stopwatch.Elapsed.Seconds;
                retornoWsTo.DeserializedNfe = notaFiscalAutorizadaTo;
                retorno.Objeto = retornoWsTo;
            }
            catch (Exception ex)
            {
                retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "EXCEPTION", Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "CDXNF0004", Mensagem = string.Format("Ocorreu um erro ao tentar consultar a nota fiscal de referência {0}.", objConsultar.referencia) });
                retorno.Status = ResultadoOperacao.Falha;
                retornoWsTo.Observacao = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                return retorno;
            }

            return retorno;
        }

        public async Task<Retorno<RetornoWsTo>> CancelarAsync(WsMobLinkService.Cancelar objCancelar)
        {
            var retorno = new Retorno<RetornoWsTo>() { Status = ResultadoOperacao.Sucesso };
            RetornoWsTo retornoWsTo = new RetornoWsTo();

            var stopwatch = new Stopwatch();

            /* Cancela nota fiscal */
            try
            {
                retornoWsTo.Etapa = Models.Enum.EtapaRequisicao.PendenteEnvio;

                WsMobLinkService.WSnfseSoapClient cliente = new WsMobLinkService.WSnfseSoapClient(WsMobLinkService.WSnfseSoapClient.EndpointConfiguration.WSnfseSoap);

                stopwatch.Start();
                var resultCancelamento = await cliente.CancelarAsync(objCancelar);
                stopwatch.Stop();

                RetornoServicoTmpTo deserializedNfe = JsonConvert.DeserializeObject<RetornoServicoTmpTo>(resultCancelamento);

                /* Padronizando retorno */
                RetornoServicoTo retornoServicoTo = new RetornoServicoTo()
                {
                    Codigo_municipo = deserializedNfe.Codigo_municipo,
                    Ref = deserializedNfe.Ref,
                    Cnpj_prestador = deserializedNfe.Cnpj_prestador,
                    Status = !string.IsNullOrEmpty(deserializedNfe.Status) ? deserializedNfe.Status : deserializedNfe.Codigo,
                    Mensagem = deserializedNfe.Mensagem
                };

                retornoWsTo.Etapa = Models.Enum.EtapaRequisicao.ComRetorno;
                retornoWsTo.TempoExecucao = stopwatch.Elapsed.Seconds;
                retornoWsTo.RetornoServicoTo = retornoServicoTo;
                retorno.Objeto = retornoWsTo;
            }
            catch (Exception ex)
            {
                retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "EXCEPTION", Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                retorno.Mensagens.Add(new MensagemSistemaDto() { Identificador = "CDXNF0004", Mensagem = string.Format("Ocorreu um erro ao tentar cancelar a nota fiscal de referência {0}.", objCancelar.referencia) });
                retorno.Status = ResultadoOperacao.Falha;
                retornoWsTo.Observacao = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty);
                return retorno;
            }

            return retorno;
        }
    }
}
