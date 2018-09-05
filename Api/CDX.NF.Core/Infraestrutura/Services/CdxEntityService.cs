using CDX.NF.Core.Infraestrutura.Persistence;
using CDX.NF.Core.Infraestrutura.Services.Tos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CDX.NF.Core.Infraestrutura.Services
{
    public abstract class CdxEntityService<T, TId> : ICdxEntityService<T, TId>
        where T : EntidadeBase<TId>
        where TId : IEquatable<TId>
    {
        public IRepository<T, TId> Repository { get; set; }

        public IList<T> ObterTodos()
        {
            return this.Repository.ObterTodos().ToList();
        }

        public T ObterPorId(TId id, params Expression<Func<T, object>>[] includes)
        {
            if (id.Equals(default(TId)))
            {
                return null;
            }

            return this.Repository.ObterPorId(id, includes);
        }

        public IList<T> ObterPorListadeIds(TId[] ids, params Expression<Func<T, object>>[] includes)
        {
            if (ids == null || ids.Length == 0)
            {
                return new List<T>();
            }

            return this.Repository.ObterPorListadeIds(ids, includes);
        }

        public void Inserir(T entity)
        {
            this.Repository.Inserir(entity);
        }

        public void Recarregar(T entity)
        {
            this.Repository.Recarregar(entity);
        }

        public bool Remover(T entity)
        {
            return this.Repository.Remover(entity);
        }

        public void Ativar(T entity)
        {
            entity.Excluido = false;
            this.Repository.Atualizar(entity);
        }

        public void Inativar(T entity)
        {
            entity.Excluido = true;
            this.Repository.Atualizar(entity);
        }

        public void Atualizar(T entity)
        {
            this.Repository.Atualizar(entity);
        }

        public void AtualizarListaePersistir(IList<T> entities, int batchSize = 100)
        {
            Repository.AtualizarListaePersistir(entities, batchSize);
        }

        public void InserirListaePersistir(IList<T> entities, int batchSize = 100)
        {
            Repository.InserirListaePersistir(entities, batchSize);
        }

        public void RemoverListaePersistir(IList<T> entities, int batchSize = 100)
        {
            Repository.RemoverListaePersistir(entities, batchSize);
        }

        public void BatchRemoverListaePersistir(Expression<Func<T, bool>> expression)
        {
            Repository.BatchRemoverListaePersistir(expression);
        }

        public void BatchAtualizarListaePersistir(Expression<Func<T, bool>> expression, Expression<Func<T, T>> updateExpression)
        {
            Repository.BatchAtualizarListaePersistir(expression, updateExpression);
        }

        public void Persistir()
        {
            this.Repository.Persistir();
        }

        public IList<T> AplicarPesquisa(PesquisaTo pesquisa, IQueryable<T> consulta, Expression<Func<T, TId>> ordenacaoPadrao = null)
        {
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

            if (!string.IsNullOrWhiteSpace(pesquisa.Ordenacao))
            {
                consulta = OrderingHelper(consulta, pesquisa.Ordenacao, pesquisa.SentidoOrdenacao == SentidoOrdenacao.Descendente);
            }
            else
            {
                if (ordenacaoPadrao == null)
                {
                    ordenacaoPadrao = c => c.Id;
                }

                if (pesquisa.SentidoOrdenacao == SentidoOrdenacao.Ascendente)
                {
                    consulta = consulta.OrderBy(ordenacaoPadrao);
                }
                else
                {
                    consulta = consulta.OrderByDescending(ordenacaoPadrao);
                }
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

        private IQueryable<T> OrderingHelper(IQueryable<T> consulta, string ordenacao, bool v)
        {
            throw new NotImplementedException();
        }

        public IList<T> AplicarPesquisaOrdenada(PesquisaTo pesquisa, IQueryable<T> consulta)
        {
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