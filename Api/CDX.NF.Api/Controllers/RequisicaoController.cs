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
    /// Controler responsavel pelo gerenciament das requisições.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class RequisicaoController : Controller
    {
        private readonly IRequisicaoService _requisicaoService;

        public RequisicaoController(IRequisicaoService requisicaoService)
        {
            _requisicaoService = requisicaoService;
        }

        [HttpGet]
        public async Task<OkObjectResult> Get(string numeroNota, int? referencia, int page, int pageCount)
        {
            var resultado = new RetornoListaDto<RequisicaoDto>() { Status = ResultadoOperacao.Sucesso };
            RequisicaoFiltroDto filtro = new RequisicaoFiltroDto();

            filtro.NumeroNota = numeroNota;
            filtro.Referencia = referencia;
            filtro.PaginaAtual = page;
            filtro.TamanhoPagina = pageCount;

            PesquisaTo pesquisa = filtro.ObterPesquisa();

            IList<Requisicao> requisicoes = await _requisicaoService.Pesquisa(filtro.ToTrasferObject(), pesquisa);

            resultado.Objeto = requisicoes.Select(c => new RequisicaoDto(c)).ToList();

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
