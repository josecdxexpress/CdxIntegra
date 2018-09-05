using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
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
    public class ParametrosRepository : IParametrosRepository
    {
        private readonly Contexto _db;

        public ParametrosRepository(Contexto context)
        {
            _db = context;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public Parametros ObterTodos(string codMunicipio, string cnpjPrestador)
        {
            var parametroObj = _db.Parametros.Include(a => a.Prestador).Include(a => a.ServicoWsSoap)
                .Where(p => p.Cidade.Codigo == codMunicipio &&
                p.Prestador.Cnpj == cnpjPrestador)
                .FirstOrDefaultAsync().Result;

            return parametroObj;
        }

        /// <summary>
        /// Obtem todos por id
        /// </summary>
        public void ObterPorId() { }

        /// <summary>
        /// Persiste um objeto
        /// </summary>
        public void Inserir() { }

        /// <summary>
        /// Altera uma nota fiscal
        /// </summary>
        public void Alterar() { }

        /// <summary>
        /// Exclui logicamente uma nota fiscal
        /// </summary>
        public void Excluir() { }

        /* Async */
        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Parametros> ObterTodosAsync(string codMunicipio, string cnpjPrestador)
        {
            var parametroObj = _db.Parametros.Include(a => a.Prestador).Include(a => a.ServicoWsSoap)
                .Where(p => p.Cidade.Codigo == codMunicipio &&
                p.Prestador.Cnpj == cnpjPrestador)
                .FirstOrDefaultAsync().Result;

            return parametroObj;
        }

        public async Task<IList<Parametros>> Pesquisa(ParametrosFiltroTo filtro, PesquisaTo pesquisa)
        {
            var consulta = _db.Parametros.Include(r => r.Cidade)
                            .Where(p => ( p.Cidade.Id == filtro.CidadeId)
                             && p.Situacao == Core.Infraestrutura.Enum.SituacaoEnum.Ativo);

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
    }
}