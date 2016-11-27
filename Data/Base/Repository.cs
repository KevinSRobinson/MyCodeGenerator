#region

#region

using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

#endregion

namespace Data.Repositories
{

    #endregion

    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _entities;


        protected Repository(SampleDbContext context)
        {
            _entities = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _entities.ToList();
        }

        public TEntity GetById(int id)
        {
            return _entities.Find(id);
        }

        public void Add(TEntity entity)
        {
            _entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _entities.Remove(entity);
        }
    }

    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
    }
}