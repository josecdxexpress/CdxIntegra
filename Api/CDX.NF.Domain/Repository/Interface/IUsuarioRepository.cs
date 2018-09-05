using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository.Interface
{
    /// <summary>
    /// Interface de repository para operações com a entidade nota fiscal.
    /// </summary>
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Usuario ObterTodos(string usuario, string senha);

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        void ObterPorId();

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        void Inserir();

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        void Alterar();

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        void Excluir();

        /* Async */
        Task<IList<Usuario>> Pesquisa(UsuarioFiltroTo filtro, PesquisaTo pesquisa);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Usuario> ObterTodosAsync(string login, string senha);

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        Task<Usuario> InserirAsync(Usuario usuario);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Usuario> AlterarAsync(UsuarioTo usuario);

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        Task<Usuario> ObterPorIdAsync(int id);

        Task<bool> ExcluirAsync(int id);
    }
}

