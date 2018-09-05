using CDX.NF.Api.Dto;
using CDX.NF.Api.Dto.Filtro;
using CDX.NF.Core.Infraestrutura.Api;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Services.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CDX.NF.Api.Extensoes;

namespace CDX.NF.Api.Controllers
{
    /// <summary>
    /// Controler responsavel por gerenciar os prestadores.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class PrestadorController : Controller
    {
        private readonly IPrestadorService _prestadorService;

        public PrestadorController(IPrestadorService prestadorService)
        {
            _prestadorService = prestadorService;
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingle))]
        public async Task<OkObjectResult> GetSingle(int id)
        {
            var resultado = new Retorno<PrestadorDto>();

            try
            {
                Prestador prestador = await _prestadorService.ObterPorIdAsync(id);
                resultado.Objeto = new PrestadorDto(prestador);
            }
            catch (Exception)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Consulta", Mensagem = string.Format(" Já existe um prestador cadastrado com esse login: {0}", id) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<OkObjectResult> Get(string nome, string login, int page, int pageCount)
        {
            var resultado = new RetornoListaDto<PrestadorDto>();
            PrestadorFiltroDto filtro = new PrestadorFiltroDto();

            filtro.Nome = nome;
            filtro.PaginaAtual = page;
            filtro.TamanhoPagina = pageCount;

            PesquisaTo pesquisa = filtro.ObterPesquisa();

            IList<Prestador> prestadores = await _prestadorService.Pesquisa(filtro.ToTransferObject(), pesquisa);

            resultado.Objeto = prestadores.Select(c => new PrestadorDto(c)).ToList();

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

            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }

        [HttpPost]
        public async Task<OkObjectResult> Post([FromBody] PrestadorDto prestadorDto)
        {
            var resultado = new Retorno<PrestadorDto>();

            Prestador prestador = await _prestadorService.InserirAsync(prestadorDto.ToEntity());

            if (prestador.Id == 0)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Inclusão", Mensagem = string.Format(" Já existe um usuário cadastrado com esse login: {0}", prestador.Cnpj) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Objeto = new PrestadorDto(prestador);
            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }

        [HttpPut]
        public async Task<OkObjectResult> Put([FromBody]PrestadorDto prestadorDto)
        {
            var resultado = new Retorno<PrestadorDto>();

            if (prestadorDto == null || !prestadorDto.Id.HasValue)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Alteração", Mensagem = string.Format(" Não foi possível efeturar a alteração!") });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            Prestador prestador = await _prestadorService.AlterarAsync(prestadorDto.ToTransferObject());

            if (prestador.Id == 0)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Inclusão", Mensagem = string.Format(" Já existe um usuário cadastrado com esse login: {0}", prestador.Cnpj) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Objeto = new PrestadorDto(prestador);
            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }

        [HttpDelete]
        [Route("{id:int}", Name = nameof(Delete))]
        public async Task<OkObjectResult> Delete(int id)
        {
            var resultado = new Retorno<bool>() { Status = ResultadoOperacao.Sucesso };

            try
            {
                var excluido = await _prestadorService.ExcluirAsync(id);

                if (!excluido)
                {
                    resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Exclusão", Mensagem = string.Format(" Não foi possível excluir o usuário {0}", id) });
                    resultado.Status = ResultadoOperacao.Falha;
                    return Ok(resultado);
                }
            }
            catch (Exception)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Exclusão", Mensagem = string.Format(" Não foi possível excluir o usuário {0}", id) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);

            }

            return Ok(resultado);
        }
    }
}
