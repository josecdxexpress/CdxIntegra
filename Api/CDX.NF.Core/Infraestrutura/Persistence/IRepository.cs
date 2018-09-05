using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CDX.NF.Core.Infraestrutura.Persistence
{
       public interface IRepository<T, TID> : IBaseRepository<T> where T : EntidadeBase<TID>
        where TID : IEquatable<TID>
    {
        T ObterPorId(TID id, params Expression<Func<T, object>>[] includes);

        IList<T> ObterPorListadeIds(TID[] ids, params Expression<Func<T, object>>[] includes);

        IQueryable<T> ObterPorExpressao(Expression<Func<T, bool>> predicate);

        void Inserir(T entity);

        bool Remover(T entity);

        void Atualizar(T entity);

        void Recarregar(T entity);

        void Persistir();

        void HabilitarExcluidos();

        void DesabilitarExcluidos();

        void InserirListaePersistir(IList<T> entities, int batchSize);

        void AtualizarListaePersistir(IList<T> entities, int batchSize);

        void RemoverListaePersistir(IList<T> entities, int batchSize);

        void BatchRemoverListaePersistir(Expression<Func<T, bool>> expression);

        void BatchAtualizarListaePersistir(Expression<Func<T, bool>> expression, Expression<Func<T, T>> updateExpression);
    }
}