using CDX.NF.Core.Infraestrutura.Persistence;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CDX.NF.Core.Infraestrutura.Services
{
    public interface ICdxEntityService<T, TId> : ICdxBaseService where T : EntidadeBase<TId>
    {
        IList<T> ObterTodos();

        T ObterPorId(TId id, params Expression<Func<T, object>>[] includes);

        IList<T> ObterPorListadeIds(TId[] ids, params Expression<Func<T, object>>[] includes);

        void Inserir(T entity);

        void Recarregar(T entity);

        bool Remover(T entity);

        void Ativar(T entity);

        void Inativar(T entity);

        void Atualizar(T entity);

        void Persistir();

        void InserirListaePersistir(IList<T> entities, int batchSize = 100);

        void AtualizarListaePersistir(IList<T> entities, int batchSize = 100);

        void RemoverListaePersistir(IList<T> entities, int batchSize = 100);

        void BatchRemoverListaePersistir(Expression<Func<T, bool>> expression);

        void BatchAtualizarListaePersistir(Expression<Func<T, bool>> expression, Expression<Func<T, T>> updateExpression);
    }
}