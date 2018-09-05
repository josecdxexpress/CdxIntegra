//using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services.Interface
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IList<Usuario>> Pesquisa(UsuarioFiltroTo filtro, PesquisaTo pesquisa)
        {
            return await _usuarioRepository.Pesquisa(filtro, pesquisa);
        }

        public async Task<Usuario> InserirAsync(Usuario usuario)
        {
            Usuario existe = await _usuarioRepository.ObterTodosAsync(usuario.Login, string.Empty);

            if (existe != null)
            {
                return usuario;
            }

            return await _usuarioRepository.InserirAsync(usuario);
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Usuario> AlterarAsync(UsuarioTo usuario)
        {
            return await _usuarioRepository.AlterarAsync(usuario);
        }

        public async Task<Usuario> ObterPorIdAsync(int id)
        {
            return await _usuarioRepository.ObterPorIdAsync(id);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            Usuario usuario = await _usuarioRepository.ObterPorIdAsync(id);

            if (usuario == null)
            {
                return false;
            }

            return await _usuarioRepository.ExcluirAsync(id);
        }
    }
}
