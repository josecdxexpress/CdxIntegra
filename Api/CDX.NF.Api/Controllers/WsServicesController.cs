using CDX.NF.Api.Dto;
using CDX.NF.Core.Infraestrutura.Api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Api.Controllers
{
    /// <summary>
    /// Controler responsavel por gerenciar os serviços.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class WsServicesController : Controller
    {
        [HttpGet]
        public async Task<OkObjectResult> Get()
        {
            var resultado = new RetornoListaDto<WsServiceDto>();

            List<WsServiceDto> lista = new List<WsServiceDto>();

            lista.Add(new WsServiceDto() { WsServiceId = 1, WsServiceDsc = "Soap" });

            resultado.Objeto = lista;

            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }
    }
}