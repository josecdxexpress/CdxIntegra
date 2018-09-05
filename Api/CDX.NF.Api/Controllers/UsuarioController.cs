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
    /// Controler responsavel por gerenciar os usuários.
    /// </summary>
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        [Route("{id:int}", Name = nameof(GetSingle))]
        public async Task<OkObjectResult> GetSingle(int id)
        {
            var resultado = new Retorno<UsuarioDto>();

            try
            {
                Usuario usuario = await _usuarioService.ObterPorIdAsync(id);
                resultado.Objeto = new UsuarioDto(usuario);
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
            var resultado = new RetornoListaDto<UsuarioDto>();
            UsuarioFiltroDto filtro = new UsuarioFiltroDto();

            filtro.Login = login;
            filtro.Nome = nome;
            filtro.PaginaAtual = page;
            filtro.TamanhoPagina = pageCount;

            PesquisaTo pesquisa = filtro.ObterPesquisa();

            IList<Usuario> usuarios = await _usuarioService.Pesquisa(filtro.ToTransferObject(), pesquisa);

            resultado.Objeto = usuarios.Select(c => new UsuarioDto(c)).ToList();

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
        public async Task<OkObjectResult> Post([FromBody]UsuarioDto usuarioDto)
        {
            var resultado = new Retorno<UsuarioDto>();

            Usuario usuario = await _usuarioService.InserirAsync(usuarioDto.ToEntity());

            if(usuario.Id == 0)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Inclusão", Mensagem = string.Format(" Já existe um usuário cadastrado com esse login: {0}", usuario.Login) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Objeto = new UsuarioDto(usuario);
            resultado.Status = ResultadoOperacao.Sucesso;

            return Ok(resultado);
        }

        [HttpPut]
        public async Task<OkObjectResult> Put([FromBody]UsuarioDto usuarioDto)
        {
            var resultado = new Retorno<UsuarioDto>();

            if (usuarioDto == null || !usuarioDto.Id.HasValue)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Alteração", Mensagem = string.Format(" Não foi possível efeturar a alteração!") });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            Usuario usuario = await _usuarioService.AlterarAsync(usuarioDto.ToTransferObject());

            if (usuario.Id == 0)
            {
                resultado.Mensagens.Add(new MensagemSistemaDto() { Titulo = "Inclusão", Mensagem = string.Format(" Já existe um usuário cadastrado com esse login: {0}", usuario.Login) });
                resultado.Status = ResultadoOperacao.Falha;
                return Ok(resultado);
            }

            resultado.Objeto = new UsuarioDto(usuario);
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
                var excluido = await _usuarioService.ExcluirAsync(id);

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
