using System;
using CDX.NF.Api.Dto;
using CDX.NF.Domain.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using CDX.NF.Api.Extensoes;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Services.Interface;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Domain.Services;

namespace AppCdx.Controllers
{
    [Route("api/[controller]")]
    public class NotaFiscalController : Controller
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly INotaFiscalService _notaFiscalBizService;

        public NotaFiscalController(INotaFiscalRepository notaFiscalRepository, INotaFiscalService notaFiscalBizService)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _notaFiscalBizService = notaFiscalBizService;
        }

        [HttpGet("{id}")]
        public string Get([FromRoute] string formaRetorno, string numero)
        {
            var resultado = new Retorno<string>();
            var pesquisaDto = new PesquisaDto() { FormaRetorno = formaRetorno, Numero = numero };

            Retorno<NotaFiscalRetornoTo> retorno = _notaFiscalRepository.ObterTodos(pesquisaDto.ToTransferObject());

            if (retorno.Status == ResultadoOperacao.Sucesso)
            {
                resultado.Status = ResultadoOperacao.Sucesso;

                if (Convert.ToInt32(pesquisaDto.FormaRetorno) == (int)TipoRetorno.Url)
                {
                    resultado.Objeto = retorno.Objeto.Url;
                }
                else if (Convert.ToInt32(pesquisaDto.FormaRetorno) == (int)TipoRetorno.Imagem)
                {
                    resultado.Objeto = retorno.Objeto.Imagem;
                }
            }
            else
            {
                resultado.Status = ResultadoOperacao.Falha;
                resultado.Mensagens.AddRange(retorno.Mensagens);
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
        }

        [HttpPost]
        public string Post([FromBody] AutorizacaoNfeDto autorizacaoNfeDto)
        {
            //var teste = _xDbxService.Obter("");
            //return null;
            var resultado = new Retorno<string>();

            try
            {
                Retorno<RetornoServicoTo> retorno = _notaFiscalBizService.Autorizar(autorizacaoNfeDto.ToTransferObject());

                if (retorno.Status != ResultadoOperacao.Sucesso)
                {
                    resultado.Mensagens.AddRange(retorno.Mensagens);
                    resultado.Status = retorno.Status;
                    return Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
                }

                resultado.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(retorno.Objeto);
                resultado.Status = ResultadoOperacao.Sucesso;
            }
            catch (Exception ex)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                resultado.Status = ResultadoOperacao.Falha;
            }

            return Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
        }

        [HttpPut]
        public string Put([FromBody] ConsultaNfeDto consultaNfeDto)
        {
            var resultado = new Retorno<string>();

            try
            {
                Retorno<NotaFiscalRetornoTo> retorno = _notaFiscalBizService.Consultar(consultaNfeDto.ToTransferObject());

                resultado.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(retorno.Objeto);

                if (retorno.Status != ResultadoOperacao.Sucesso)
                {
                    resultado.Status = retorno.Status;
                    resultado.Mensagens.AddRange(retorno.Mensagens);
                }
            }
            catch (Exception ex)
            { 
                resultado.Mensagens.Add(new MensagemSistemaDto() { Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                resultado.Status = ResultadoOperacao.Falha;
            }

            resultado.Status = ResultadoOperacao.Sucesso;
            return Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
        }

        [HttpDelete]
        public string Delete([FromBody] CancelamentoNfeDto cancelamentoNfeDto)
        {
            var resultado = new Retorno<string>();

            try
            {
                Retorno<RetornoServicoTo> retorno = _notaFiscalBizService.Cancelar(cancelamentoNfeDto.ToTransferObject());

                resultado.Objeto = Newtonsoft.Json.JsonConvert.SerializeObject(retorno.Objeto);

                if (retorno.Status != ResultadoOperacao.Sucesso)
                {
                    resultado.Status = retorno.Status;
                    resultado.Mensagens.AddRange(retorno.Mensagens);
                }
            }
            catch (Exception ex)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                resultado.Status = ResultadoOperacao.Falha;
            }

            resultado.Status = ResultadoOperacao.Sucesso;
            return Newtonsoft.Json.JsonConvert.SerializeObject(resultado);
        }
    }
}