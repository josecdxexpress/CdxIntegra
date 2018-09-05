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
    public class ParametrosService: IParametrosService
    {
        private readonly IParametrosRepository _parametrosRepository;

        public ParametrosService(IParametrosRepository parametrosRepository)
        {
            _parametrosRepository = parametrosRepository;
        }

        public async Task<IList<Parametros>> Pesquisa(ParametrosFiltroTo filtro, PesquisaTo pesquisa)
        {
            return await _parametrosRepository.Pesquisa(filtro, pesquisa);
        }
    }
}
