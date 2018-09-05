using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
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
    public interface ICidadeNfeRepository
    {
        Task<IList<Cidade>> Pesquisa(CidadeFiltroTo filtro, PesquisaTo pesquisa);


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Cidade> ObterTodosAsync(string login, string senha);


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Cidade> InserirAsync(Cidade cidade);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Cidade> AlterarAsync(CidadeTo cidade);


        /// <summary>
        /// Obtem todos por id
        /// </summary>
        Task<Cidade> ObterPorIdAsync(int id);


        Task<bool> ExcluirAsync(int id);
    }

}
