using CDX.NF.Core.Infraestrutura.Enum;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository
{
    public class PrestadorRepository : IPrestadorRepository
    {
        private readonly Contexto _db;

        public PrestadorRepository(Contexto context)
        {
            _db = context;
        }

        public async Task<IList<Prestador>> Pesquisa(PrestadorFiltroTo filtro, PesquisaTo pesquisa)
        {
            var consulta = _db.Prestador
                            .Where(p => 
                            //(string.IsNullOrEmpty(filtro.Nome) || EF.Functions.Like(p.Nome, $"%{filtro.Nome}%"))
                            //&& 
                            (string.IsNullOrEmpty(filtro.Cnpj) || EF.Functions.Like(p.Cnpj, $"%{filtro.Cnpj}%")) && p.Situacao == SituacaoEnum.Ativo);

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
        public async Task<Prestador> ObterTodosAsync(string nome, string cnpj)
        {
            var usuarioObj = _db.Prestador
                            .Where(p => 
                            //(string.IsNullOrEmpty(nome) || EF.Functions.Like(p.nome, $"%{login}%"))
                            //&& 
                            (string.IsNullOrEmpty(cnpj) || EF.Functions.Like(p.Cnpj, $"%{cnpj}%")) && p.Situacao == SituacaoEnum.Ativo)
            .FirstOrDefaultAsync();

            return await usuarioObj;
        }


        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Prestador> InserirAsync(Prestador prestador)
        {
            prestador.Situacao = SituacaoEnum.Ativo;
            var notaObj = await _db.Prestador.AddAsync(prestador);
            _db.SaveChanges();

            return prestador;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Prestador> AlterarAsync(PrestadorTo prestador)
        {
            Prestador prestadorObj = await _db.Prestador.Where(p => p.Id == prestador.Id).FirstOrDefaultAsync();
            prestadorObj.Cnpj = prestador.Cnpj;

            var prestadorAlterado = _db.Prestador.Update(prestadorObj);
            _db.SaveChanges();

            return prestadorObj;
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public async Task<Prestador> ObterPorIdAsync(int id)
        {
            var prestadorObj = _db.Prestador
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();

            return await prestadorObj;
        }

        public async Task<bool> ExcluirAsync(int id)
        {
            var prestadorObj = await _db.Prestador.Where(p => p.Id == id).FirstOrDefaultAsync();

            prestadorObj.Situacao = SituacaoEnum.Excluido;

            _db.Prestador.Update(prestadorObj);
            _db.SaveChanges();

            return true;
        }
    }
}