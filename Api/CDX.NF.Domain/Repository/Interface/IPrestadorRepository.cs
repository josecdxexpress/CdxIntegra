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
    public interface IPrestadorRepository
    {

        Task<IList<Prestador>> Pesquisa(PrestadorFiltroTo filtro, PesquisaTo pesquisa);


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Prestador> ObterTodosAsync(string nome, string cnpj);


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Prestador> InserirAsync(Prestador prestador);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Prestador> AlterarAsync(PrestadorTo prestador);


        /// <summary>
        /// Obtem todos por id
        /// </summary>
        Task<Prestador> ObterPorIdAsync(int id);


        Task<bool> ExcluirAsync(int id);
    }
}

