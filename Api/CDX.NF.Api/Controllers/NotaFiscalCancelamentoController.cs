﻿using CDX.NF.Api.Dto;
using CDX.NF.Api.Extensoes;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using CDX.NF.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CDX.NF.Api.Controllers
{
    /// <summary>
    /// Controler responsável pelo cancelamento de nota fiscal.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class NotaFiscalCancelamentoController : Controller
    {
        private readonly INotaFiscalRepository _notaFiscalRepository;
        private readonly INotaFiscalService _notaFiscalBizService;

        public NotaFiscalCancelamentoController(INotaFiscalRepository notaFiscalRepository, INotaFiscalService notaFiscalBizService)
        {
            _notaFiscalRepository = notaFiscalRepository;
            _notaFiscalBizService = notaFiscalBizService;
        }

        /// <summary>
        /// Metodos responsavel por cancelar uma nota fiscal.
        /// </summary>
        /// <param name="cancelamentoNfeDto"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<Retorno<RetornoServicoTo>> Post([FromBody]CancelamentoNfeDto cancelamentoNfeDto)
        {
            var resultado = new Retorno<RetornoServicoTo>() { Status = ResultadoOperacao.Sucesso };

            try
            {
                resultado = await _notaFiscalBizService.CancelarAsync(cancelamentoNfeDto.ToTransferObject());
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
