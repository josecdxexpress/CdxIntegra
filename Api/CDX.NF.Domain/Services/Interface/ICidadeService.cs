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
    public interface ICidadeService
    {
        Task<IList<Cidade>> Pesquisa(CidadeFiltroTo filtro, PesquisaTo pesquisa);

        Task<Cidade> InserirAsync(Cidade cidade);

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        Task<Cidade> AlterarAsync(CidadeTo cidade);

        Task<Cidade> ObterPorIdAsync(int id);

        Task<bool> ExcluirAsync(int id);
    }
}
