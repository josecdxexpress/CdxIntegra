using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace CDX.NF.Core.Infraestrutura.Persistence
{
    public class GenericBaseRepository<T> where T : class
    {
        private DbContext _entities;
        //private IDbSet<T> _dbset;

        public GenericBaseRepository(DbContext context)
        {
            _entities = context;
            //_dbset = context.Set<T>();
        }

        //public Database Database
        //{
        //    get
        //    {
        //        return _entities.Database;
        //    }
        //}

        //public ILogger Logger { get; set; }

        protected DbContext Context
        {
            get
            {
                return _entities;
            }
        }

        //protected IDbSet<T> DbSet
        //{
        //    get
        //    {
        //        return _dbset;
        //    }
        //}

        //public virtual IQueryable<T> ObterTodos()
        //{
        //    return _dbset;
        //}

        public virtual IQueryable<TJoinEntity> ObterTodos<TJoinEntity>()
            where TJoinEntity : class
        {
            return _entities.Set<TJoinEntity>().AsQueryable();
        }
    }
}