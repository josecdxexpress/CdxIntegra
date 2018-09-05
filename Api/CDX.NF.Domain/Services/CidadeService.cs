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
    public class CidadeService: ICidadeService
    {
        private readonly ICidadeNfeRepository _cidadeRepository;

        public CidadeService(ICidadeNfeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        public async Task<IList<Cidade>> Pesquisa(CidadeFiltroTo filtro, PesquisaTo pesquisa)
        {
            return await _cidadeRepository.Pesquisa(filtro, pesquisa);
        }

        public async Task<Cidade> InserirAsync(Cidade cidade)
        {
            Cidade existe = await _cidadeRepository.ObterTodosAsync(cidade.Codigo, string.Empty);

            if (existe != null)
            {
                return cidade;
            }

            return await _cidadeRepository.InserirAsync(cidade);
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Cidade> AlterarAsync(CidadeTo cidade)
        {
            return await _cidadeRepository.AlterarAsync(cidade);
        }

        public async Task<Cidade> ObterPorIdAsync(int id)
        {
            return await _cidadeRepository.ObterPorIdAsync(id);
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            Cidade cidade = await _cidadeRepository.ObterPorIdAsync(id);

            if (cidade == null)
            {
                return false;
            }

            return await _cidadeRepository.ExcluirAsync(id);
        }
    }
}
