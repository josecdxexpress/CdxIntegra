using CDX.NF.Core.Infraestrutura.Services.Tos;
using CDX.NF.Domain.Infraestrutura.Conexao;
using CDX.NF.Domain.Models;
using CDX.NF.Domain.Models.Enum;
using CDX.NF.Domain.Models.To;
using CDX.NF.Domain.Models.To.Filtro;
using CDX.NF.Domain.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDX.NF.Domain.Repository
{
    public class RequisicaoRepository : IRequisicaoRepository
    {
        private readonly Contexto _db;

        public RequisicaoRepository(Contexto context)
        {
            _db = context;
        }

        /// <summary>
        /// Obtem todos por parametros
        /// </summary>
        public Requisicao ObterTodos(int referencia, TipoOperacao tipoOperacao)
        {
            var requisicaoObj = _db.Requisicao.Where(p => p.Referencia == referencia && p.TipoOperacao == tipoOperacao).FirstOrDefaultAsync().Result;
            return requisicaoObj;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public Requisicao ObterPorId(int id)
        {
            return _db.Requisicao.Where(p => p.Id == id).FirstOrDefaultAsync().Result;
        }

        /// <summary>
        /// Persiste um objeto requisição
        /// </summary>
        public int Inserir(Requisicao  requisicao) {
            var requisicaoObj = _db.Requisicao.AddAsync(requisicao).Result;
            _db.SaveChanges();

            return requisicao.Id;
        }

        /// <summary>
        /// Altera uma requisição
        /// </summary>
        public void Alterar(Requisicao requisicao)
        {
            var requisicaoObj = _db.Requisicao.Update(requisicao);
            _db.SaveChanges();
        }

        /// <summary>
        /// Exclui logicamente uma requisição
        /// </summary>
        public void Excluir()
        {
        }

        /// <summary>
        /// Obtem requisição por referencia, tipo de operação e etapa.
        /// </summary>
        public Requisicao ObterTodosPorStatus(int referencia, TipoOperacao tipoOperacao, EtapaRequisicao etapa, StatusOperacao status)
        {
            var requisicaoObj = _db.Requisicao.Include(a => a.ServicoWsSoap).Where(p => p.Referencia == referencia && p.TipoOperacao == tipoOperacao && p.Etapa == etapa && p.Status == status)
                .OrderBy(o => o.DataCadastro).FirstOrDefaultAsync().Result;
            return requisicaoObj;
        }

        /* Async */

        /// <summary>
        /// Obtem todos por parametros
        /// </summary>
        public async Task<Requisicao> ObterTodosAsync(int referencia, TipoOperacao tipoOperacao)
        {
            var requisicaoObj = _db.Requisicao.Where(p => p.Referencia == referencia && p.TipoOperacao == tipoOperacao).FirstOrDefaultAsync();

            return await requisicaoObj;
        }

        /// <summary>
        /// Obtem requisição por referencia, tipo de operação e etapa.
        /// </summary>
        public async Task<Requisicao> ObterTodosPorStatusAsync(int referencia, TipoOperacao tipoOperacao, EtapaRequisicao etapa, StatusOperacao status)
        {
            var requisicaoObj = _db.Requisicao.Include(a => a.ServicoWsSoap).Where(p => p.Referencia == referencia && p.TipoOperacao == tipoOperacao && p.Etapa == etapa && p.Status == status)
                .OrderBy(o => o.DataCadastro).FirstOrDefaultAsync();
            return await requisicaoObj;
        }

        /// <summary>
        /// Altera uma requisição
        /// </summary>
        public async void AlterarAsync(Requisicao requisicao)
        {
            var requisicaoObj = _db.Requisicao.Update(requisicao);
            _db.SaveChanges();
        }

        /// <summary>
        /// Persiste um objeto requisição
        /// </summary>
        public async Task<int> InserirAsync(Requisicao requisicao)
        {
            var requisicaoObj = await _db.Requisicao.AddAsync(requisicao);
            _db.SaveChanges();

            return requisicao.Id;
        }

        /// <summary>
        /// Obtem todos por parametro
        /// </summary>
        public async Task<Requisicao> ObterPorIdAsync(int id)
        {
            return await _db.Requisicao.Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IList<Requisicao>> Pesquisa(RequisicaoFiltroTo filtro, PesquisaTo pesquisa)
        {
            //return _db.Clientes
            //    .Where(p => (!p.EmpresaId.HasValue || p.EmpresaId == empresaId)
            //    && p.Situacao == SituacaoEnum.Ativo
            //    && (string.IsNullOrEmpty(nome) || EF.Functions.Like(p.Nome, $"%{nome}%"))
            //    && (string.IsNullOrEmpty(documento) || EF.Functions.Like(p.CpfCnpj, $"%{documento}%")))
            //    .OrderByDescending(o => o.Id)
            //    .AsNoTracking()
            //    .Take(15)
            //    .ToListAsync();

            var consulta = _db.Requisicao.Include(r => r.NotaFiscalAutorizada).Include(r => r.Cidade).Include(r => r.Prestador).Include(r => r.ServicoWsSoap)
                            .Where(p => (string.IsNullOrEmpty(filtro.NumeroNota) || (p.NotaFiscalAutorizada.Numero == filtro.NumeroNota))
                            && (!filtro.Referencia.HasValue || (p.Referencia == filtro.Referencia)) && p.Situacao == Core.Infraestrutura.Enum.SituacaoEnum.Ativo);

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
