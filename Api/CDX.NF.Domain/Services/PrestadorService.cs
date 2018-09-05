using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using CDX.NF.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Services
{
    public class PrestadorService : IPrestadorService
    {
        private readonly IPrestadorRepository _prestadorRepository;
        public PrestadorService(IPrestadorRepository prestadorRepository)
        {
            _prestadorRepository = prestadorRepository;
        }

        public async Task<IList<Prestador>> Pesquisa(PrestadorFiltroTo filtro, PesquisaTo pesquisa)
        {
            return await _prestadorRepository.Pesquisa(filtro, pesquisa);
        }

        public async Task<Prestador> InserirAsync(Prestador prestador)
        {
            Prestador existe = await _prestadorRepository.ObterTodosAsync(prestador.Cnpj, string.Empty);

            if (existe != null)
            {
                return prestador;
            }

            return await _prestadorRepository.InserirAsync(prestador);
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Prestador> AlterarAsync(PrestadorTo prestador)
        {
            return await _prestadorRepository.AlterarAsync(prestador);
        }

        public async Task<Prestador> ObterPorIdAsync(int id)
        {
            return await _prestadorRepository.ObterPorIdAsync(id);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            Prestador usuario = await _prestadorRepository.ObterPorIdAsync(id);

            if (usuario == null)
            {
                return false;
            }

            return await _prestadorRepository.ExcluirAsync(id);
        }
    }
}
