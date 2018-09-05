using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To.Filtro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services.Interface
{
    public interface IRequisicaoService
    {
        Task<IList<Requisicao>> Pesquisa(RequisicaoFiltroTo filtro, PesquisaTo pesquisa);
    }
}
