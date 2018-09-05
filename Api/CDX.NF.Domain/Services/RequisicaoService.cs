using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using CDX.NF.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services
{
    public class RequisicaoService : IRequisicaoService
    {
        private readonly IRequisicaoRepository _requisicaoRepository;

        public RequisicaoService(IRequisicaoRepository requisicaoRepository)
        {
            _requisicaoRepository = requisicaoRepository;
        }

        public async Task<IList<Requisicao>> Pesquisa(RequisicaoFiltroTo filtro, PesquisaTo pesquisa)
        {
            return await _requisicaoRepository.Pesquisa(filtro, pesquisa);
        }
    }
}
