using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CDX.NF.Core.Infraestrutura.Persistence
{
    /// <summary>
    /// Generic repository
    /// </summary>
    /// <typeparam name="T">Classe do model</typeparam>
    /// <typeparam name="TId">Tipo do Id</typeparam>
    public class GenericRepository<T, TId> : GenericBaseRepository<T>, IRepository<T, TId>
        where T : EntidadeBase<TId>
        where TId : IEquatable<TId>
    {
        public GenericRepository(DbContext context)
            : base(context)
        {
        }

        public Database Database { get; }

        public IQueryable<T> ObterTodos() { return null; }

        public IQueryable<T> ObterPorExpressao(Expression<Func<T, bool>> predicate)
        {
            IQueryable<T> query = this.ObterTodos().Where(predicate);
            return query;
        }

        public virtual T ObterPorId(TId id, params Expression<Func<T, object>>[] includes)
        {
            var dataBaseSet = Context
                .Set<T>()
                .AsQueryable();

            foreach (var include in includes)
            {
                dataBaseSet = dataBaseSet.Include(include);
            }

            var entidade = dataBaseSet.FirstOrDefault(ent => ent.Id.Equals(id));

            return entidade;
        }

        public virtual IList<T> ObterPorListadeIds(TId[] ids, params Expression<Func<T, object>>[] includes)
        {
            var dataBaseSet = Context
                .Set<T>()
                .AsQueryable();

            foreach (var include in includes)
            {
                dataBaseSet = dataBaseSet.Include(include);
            }

            var entidades = dataBaseSet
                                .Where(ent => ids.Contains(ent.Id))
                                .ToList();

            return entidades;
        }

        public virtual void Inserir(T entity)
        {
            //DbSet.Add(entity);
        }

        public virtual void Recarregar(T entity)
        {
            Context.Entry(entity).Reload();
        }

        public virtual bool Remover(T entity)
        {
            if (entity == null)
            {
                return false;
            }

            entity.Excluido = true;
            Atualizar(entity);

            return true;
        }

        public virtual void Atualizar(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
        }

        public void HabilitarExcluidos()
        {
            //Context.DisableFilter("Excluido");
        }

        public void DesabilitarExcluidos()
        {
            //Context.EnableFilter("Excluido");
        }

        public virtual void Persistir()
        {
            Context.SaveChanges();
        }

        public virtual void InserirListaePersistir(IList<T> entities, int batchSize)
        {
            //var pages = entities
            //    .GroupBy(a => entities.IndexOf(a) / batchSize)
            //    .ToList();

            //try
            //{
            //    List<Task> tasks = new List<Task>();
            //    Context.Configuration.AutoDetectChangesEnabled = false;
            //    Context.Configuration.ValidateOnSaveEnabled = false;

            //    foreach (var page in pages)
            //    {
            //        foreach (var entity in page)
            //        {
            //            DbSet.Add(entity);
            //        }

            //        tasks.Add(Context.SaveChangesAsync());
            //    }

            //    Task.WaitAll(tasks.ToArray());
            //}
            //finally
            //{
            //    Context.Configuration.AutoDetectChangesEnabled = true;
            //    Context.Configuration.ValidateOnSaveEnabled = true;
            //}
        }

        public virtual void AtualizarListaePersistir(IList<T> entities, int batchSize)
        {
            //var pages = entities
            //    .GroupBy(a => entities.IndexOf(a) / batchSize)
            //    .ToList();

            //List<Task> tasks = new List<Task>();

            //try
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = false;
            //    Context.Configuration.ValidateOnSaveEnabled = false;

            //    foreach (var page in pages)
            //    {
            //        foreach (var entity in page)
            //        {
            //            Context.Entry(entity).State = EntityState.Modified;
            //        }

            //        ////Context.ChangeTracker.DetectChanges();

            //        tasks.Add(Context.SaveChangesAsync());
            //    }

            //    Task.WaitAll(tasks.ToArray());
            //}
            //finally
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = true;
            //    Context.Configuration.ValidateOnSaveEnabled = true;
            //}
        }

        public virtual void RemoverListaePersistir(IList<T> entities, int batchSize)
        {
            //var pages = entities
            //    .GroupBy(a => entities.IndexOf(a) / batchSize)
            //    .ToList();

            //List<Task> tasks = new List<Task>();

            //try
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = false;
            //    Context.Configuration.ValidateOnSaveEnabled = false;

            //    foreach (var page in pages)
            //    {
            //        foreach (var entity in page)
            //        {
            //            Context.Entry(entity).State = EntityState.Deleted;
            //        }

            //        ////Context.ChangeTracker.DetectChanges();

            //        tasks.Add(Context.SaveChangesAsync());
            //    }

            //    Task.WaitAll(tasks.ToArray());
            //}
            //finally
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = true;
            //    Context.Configuration.ValidateOnSaveEnabled = true;
            //}
        }

        public void BatchRemoverListaePersistir(Expression<Func<T, bool>> expression)
        {
            //try
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = false;
            //    Context.Configuration.ValidateOnSaveEnabled = false;
            //    Context.Set<T>().Where(expression).Delete();
            //}
            //finally
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = true;
            //    Context.Configuration.ValidateOnSaveEnabled = true;
            //}
        }

        public void BatchAtualizarListaePersistir(Expression<Func<T, bool>> expression, Expression<Func<T, T>> updateExpression)
        {
            //try
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = false;
            //    Context.Configuration.ValidateOnSaveEnabled = false;
            //    Context.Set<T>().Where(expression).Update(updateExpression);
            //}
            //finally
            //{
            //    ////Context.Configuration.AutoDetectChangesEnabled = true;
            //    Context.Configuration.ValidateOnSaveEnabled = true;
            //}
        }
    }
}