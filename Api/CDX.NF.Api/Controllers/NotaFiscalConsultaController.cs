using CDX.NF.Api.Dto;
using CDX.NF.Api.Extensoes;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Repository.Interface;
using CDX.NF.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CDX.NF.Api.Controllers
{
    /// <summary>
    /// Controler responsavel por consultar e obter uma nota fiscal.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class NotaFiscalConsultaController : Controller
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly INotaFiscalService _notaFiscalBizService;

        public NotaFiscalConsultaController(INotaFiscalRepository notaFiscalRepository, INotaFiscalService notaFiscalBizService)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _notaFiscalBizService = notaFiscalBizService;
        }

        /// <summary>
        /// Metodo responsavel por consultar e obter uma nota fiscal.
        /// </summary>
        [HttpPost]
        public async Task<Retorno<NotaFiscalRetornoTo>> Post([FromBody]ConsultaNfeDto consultaNfeDto)
        {
            Retorno<NotaFiscalRetornoTo> resultado = new Retorno<NotaFiscalRetornoTo>() { Status = ResultadoOperacao.Sucesso };

            try
            {
                resultado = await _notaFiscalBizService.ConsultarAsync(consultaNfeDto.ToTransferObject());
            }
            catch (Exception ex)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Mensagem = string.Format("{0} - {1}", ex.Message, ex.InnerException != null ? ex.InnerException.Message : string.Empty) });
                resultado.Status = ResultadoOperacao.Falha;
            }

            return resultado;
        }
    }
}
