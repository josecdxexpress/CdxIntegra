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
    public interface IPrestadorService
    {
        Task<IList<Prestador>> Pesquisa(PrestadorFiltroTo filtro, PesquisaTo pesquisa);

        Task<Prestador> InserirAsync(Prestador usuario);


        Task<Prestador> ObterPorIdAsync(int id);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Prestador> AlterarAsync(PrestadorTo usuario);

        Task<bool> ExcluirAsync(int id);
    }
}
