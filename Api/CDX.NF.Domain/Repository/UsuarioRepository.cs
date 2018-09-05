using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _db;

        public UsuarioRepository(Contexto context)
        {
            _db = context;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public Usuario ObterTodos(string usuario, string senha)
        {
            var usuarioObj = _db.Usuario
            .Where(p => p.Login == usuario && p.Senha == senha)
            .FirstOrDefaultAsync().Result;

            return usuarioObj;
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public void ObterPorId() { }

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        public void Inserir() {

        }

        ///// <summary>
        ///// Persiste um objeto
        ///// </summary>
        //public async Task<Usuario> InserirAsync(Usuario usuario)
        //{
        //    var usuarioObj = await _db.Usuario.AddAsync(usuario);
        //    _db.SaveChanges();

        //    return await _db.Usuario.Where(p => p.Id == usuarioObj.Id).FirstOrDefaultAsync();
        //}

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        public void Alterar() { }

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        public void Excluir() { }

        /* Async */

        public async Task<IList<Usuario>> Pesquisa(UsuarioFiltroTo filtro, PesquisaTo pesquisa)
        {
            var consulta = _db.Usuario
                            .Where(p => (string.IsNullOrEmpty(filtro.Login) || EF.Functions.Like(p.Login, $"%{filtro.Login}%"))
                            && (string.IsNullOrEmpty(filtro.Nome) || EF.Functions.Like(p.Nome, $"%{filtro.Nome}%")) && p.Situacao == SituacaoEnum.Ativo);
            //    .OrderByDescending(o => o.Id)
            //    .AsNoTracking()

            if (pesquisa == null)
            {
                return consulta.ToList();
            }

            int excludedRows = 0;

            pesquisa.TotalRegistros = consulta.Count();

            if (pesquisa.TamanhoPagina.HasValue && pesquisa.PaginaAtual.HasValue)
            {
                if (pesquisa.TotalRegistros <= pesquisa.TamanhoPagina || pesquisa.PaginaAtual <= 0)
                {
                    pesquisa.PaginaAtual = 1;
                }

                excludedRows = (pesquisa.PaginaAtual.Value - 1) * pesquisa.TamanhoPagina.Value;
            }

            if (excludedRows > 0)
            {
                consulta = consulta.Skip(excludedRows);
            }

            if (pesquisa.TamanhoPagina.HasValue)
            {
                consulta = consulta.Take(pesquisa.TamanhoPagina.Value);
            }

            return consulta.ToList();
        }


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Usuario> ObterTodosAsync(string login, string senha)
        {
            var usuarioObj = _db.Usuario
                            .Where(p => (string.IsNullOrEmpty(login) || EF.Functions.Like(p.Login, $"%{login}%"))
                            && (string.IsNullOrEmpty(senha) || EF.Functions.Like(p.Nome, $"%{senha}%")) && p.Situacao == SituacaoEnum.Ativo)
            .FirstOrDefaultAsync();

            return await usuarioObj;
        }


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Usuario> InserirAsync(Usuario usuario)
        {
            usuario.Situacao = SituacaoEnum.Ativo;
            var notaObj = await _db.Usuario.AddAsync(usuario);
            _db.SaveChanges();

            return usuario;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Usuario> AlterarAsync(UsuarioTo usuario)
        {
            Usuario usuarioObj = await _db.Usuario.Where(p => p.Id == usuario.Id).FirstOrDefaultAsync();
            usuarioObj.Nome = usuario.Nome;
            usuarioObj.Login = usuario.Login;
            usuarioObj.Senha = usuario.Senha;
            usuarioObj.Email = usuario.Email;

            var usuarioAlterado = _db.Usuario.Update(usuarioObj);
            _db.SaveChanges();

            return usuarioObj;
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            var usuarioObj = _db.Usuario
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

            return await usuarioObj;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var usuarioObj = await _db.Usuario.Where(p => p.Id == id).FirstOrDefaultAsync();

            usuarioObj.Situacao = SituacaoEnum.Excluido;

            _db.Usuario.Update(usuarioObj);
            _db.SaveChanges();

            return true;
        }
    }
}