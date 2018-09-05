using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository
{
      public class CidadeNfeRepository : ICidadeNfeRepository
    {
        private readonly Contexto _db;

        public CidadeNfeRepository(Contexto context)
        {
            _db = context;
        }

        public async Task<IList<Cidade>> Pesquisa(CidadeFiltroTo filtro, PesquisaTo pesquisa)
        {
            var consulta = _db.Cidade
                            .Where(p => (string.IsNullOrEmpty(filtro.Codigo) || EF.Functions.Like(p.Codigo, $"%{filtro.Codigo}%"))
                            && (string.IsNullOrEmpty(filtro.Nome) || EF.Functions.Like(p.Descricao, $"%{filtro.Nome}%")) && p.Situacao == SituacaoEnum.Ativo);

            if (pesquisa == null)
            {
                return consulta.ToList();
            }

            int excludedRows = 0;

            pesquisa.TotalRegistros = consulta.Count();

            if (pesquisa.TamanhoPagina.HasValue && pesquisa.PaginaAtual.HasValue)
            {
                if (pesquisa.TotalRegistros <= pesquisa.TamanhoPagina || pesquisa.PaginaAtual <= 0)
                {
                    pesquisa.PaginaAtual = 1;
                }

                excludedRows = (pesquisa.PaginaAtual.Value - 1) * pesquisa.TamanhoPagina.Value;
            }

            if (excludedRows > 0)
            {
                consulta = consulta.Skip(excludedRows);
            }

            if (pesquisa.TamanhoPagina.HasValue)
            {
                consulta = consulta.Take(pesquisa.TamanhoPagina.Value);
            }

            return consulta.ToList();
        }


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Cidade> ObterTodosAsync(string codigo, string nome)
        {
            var usuarioObj = _db.Cidade
                            .Where(p => (string.IsNullOrEmpty(codigo) || EF.Functions.Like(p.Codigo, $"%{codigo}%"))
                            && (string.IsNullOrEmpty(nome) || EF.Functions.Like(p.Descricao, $"%{nome}%")) && p.Situacao == SituacaoEnum.Ativo)
            .FirstOrDefaultAsync();

            return await usuarioObj;
        }


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Cidade> InserirAsync(Cidade cidade)
        {
            cidade.Situacao = SituacaoEnum.Ativo;
            var notaObj = await _db.Cidade.AddAsync(cidade);
            _db.SaveChanges();

            return cidade;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Cidade> AlterarAsync(CidadeTo cidade)
        {
            Cidade cidadeObj = await _db.Cidade.Where(p => p.Id == cidade.Id).FirstOrDefaultAsync();
            cidadeObj.Descricao = cidade.Descricao;


            var usuarioAlterado = _db.Cidade.Update(cidadeObj);
            _db.SaveChanges();

            return cidadeObj;
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public async Task<Cidade> ObterPorIdAsync(int id)
        {
            var cidadeObj = _db.Cidade
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

            return await cidadeObj;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var cidadeObj = await _db.Cidade.Where(p => p.Id == id).FirstOrDefaultAsync();

            cidadeObj.Situacao = SituacaoEnum.Excluido;

            _db.Cidade.Update(cidadeObj);
            _db.SaveChanges();

            return true;
        }
    }
}
