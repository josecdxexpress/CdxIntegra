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
    /// Controler responsavel por gerenciar as cidades.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class CidadeController : Controller
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingle))]
        public async Task<OkObjectResult> GetSingle(int id)
        {
            var resultado = new Retorno<CidadeDto>();

            try
            {
                Cidade cidade = await _cidadeService.ObterPorIdAsync(id);
                resultado.Objeto = new CidadeDto(cidade);
            }
            catch (Exception)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Consulta", Mensagem = string.Format(" Já existe um usuário cadastrado com esse login: {0}", id) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }

        [HttpGet]
        public async Task<OkObjectResult> Get(string nome, string login, int page, int pageCount)
        {
            var resultado = new RetornoListaDto<CidadeDto>();
            CidadeFiltroDto filtro = new CidadeFiltroDto();

            filtro.Nome = nome;
            filtro.PaginaAtual = page;
            filtro.TamanhoPagina = pageCount;

            PesquisaTo pesquisa = filtro.ObterPesquisa();

            IList<Cidade> cidades = await _cidadeService.Pesquisa(filtro.ToTransferObject(), pesquisa);

            resultado.Objeto = cidades.Select(c => new CidadeDto(c)).ToList();

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
        public async Task<OkObjectResult> Post([FromBody]CidadeDto cidadeDto)
        {
            var resultado = new Retorno<CidadeDto>();

            Cidade cidade = await _cidadeService.InserirAsync(cidadeDto.ToEntity());

            if (cidade.Id == 0)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Inclusão", Mensagem = string.Format(" Já existe um usuário cadastrado com esse login: {0}", cidade.Descricao) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Objeto = new CidadeDto(cidade);
            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }

        [HttpPut]
        public async Task<OkObjectResult> Put([FromBody]CidadeDto cidadeDto)
        {
            var resultado = new Retorno<CidadeDto>();

            if (cidadeDto == null || !cidadeDto.Id.HasValue)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Alteração", Mensagem = string.Format(" Não foi possível efeturar a alteração!") });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            Cidade cidade = await _cidadeService.AlterarAsync(cidadeDto.ToTransferObject());

            if (cidade.Id == 0)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Inclusão", Mensagem = string.Format(" Já existe um usuário cadastrado com esse login: {0}", cidade.Descricao) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Objeto = new CidadeDto(cidade);
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
                var excluido = await _cidadeService.ExcluirAsync(id);

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
