using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services.Interface
{
    public interface IUsuarioService
    {
        Task<IList<Usuario>> Pesquisa(UsuarioFiltroTo filtro, PesquisaTo pesquisa);

        Task<Usuario> InserirAsync(Usuario usuario);


        Task<Usuario> ObterPorIdAsync(int id);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Usuario> AlterarAsync(UsuarioTo usuario);

        Task<bool> ExcluirAsync(int id);
    }
}
