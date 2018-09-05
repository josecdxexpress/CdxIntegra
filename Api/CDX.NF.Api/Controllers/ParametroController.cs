using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Domain.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDX.NF.Api.Dto;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Api.Extensoes;
using Microsoft.AspNetCore.Authorization;
using CDX.NF.Api.Dto.Filtro;

namespace CDX.NF.Api.Controllers
{
    /// <summary>
    /// Controler responsavel pelo gerenciament dos parametros.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class ParametroController: Controller
    {
        private readonly IParametrosService _parametrosService;

        public ParametroController(IParametrosService parametrosService)
        {
            _parametrosService = parametrosService;
        }

        [HttpGet]
        public async Task<OkObjectResult> Get(int? usuarioId, int? cidadeId, int page, int pageCount)
        {
            var resultado = new RetornoListaDto<ParametrosDto>() { Status = ResultadoOperacao.Sucesso };
            ParametrosFiltroDto filtro = new ParametrosFiltroDto();

            filtro.CidadeId = cidadeId;
            filtro.UsuarioId = usuarioId;
            filtro.PaginaAtual = page;
            filtro.TamanhoPagina = pageCount;

            PesquisaTo pesquisa = filtro.ObterPesquisa();

            IList<Parametros> requisicoes = await _parametrosService.Pesquisa(filtro.ToTrasferObject(), pesquisa);

            resultado.Objeto = requisicoes.Select(c => new ParametrosDto(c)).ToList();

            if (pesquisa != null)
            {
                resultado.TotalRegistros = pesquisa.TotalRegistros;
                resultado.PaginaAtual = pesquisa.PaginaAtual;
                resultado.Ordenacao = pesquisa.Ordenacao;
                resultado.TamanhoPagina = pesquisa.TamanhoPagina;
            }
            else
            {
                resultado.TotalRegistros = resultado.Objeto.Count;
            }

            return Ok(resultado);
        }
    }
}
