using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository.Interface
{
    /// <summary>
    /// Interface de repository para operações com a entidade nota fiscal.
    /// </summary>
    public interface IParametrosRepository
    {
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Parametros ObterTodos(string codMunicipio, string cnpjPrestador);

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
        Task<Parametros> ObterTodosAsync(string codMunicipio, string cnpjPrestador);

        Task<IList<Parametros>> Pesquisa(ParametrosFiltroTo filtro, PesquisaTo pesquisa);
    }
}
