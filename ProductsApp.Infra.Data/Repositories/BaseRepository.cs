using ProductsApp.Domain.Interfaces.Repositories;
using ProductsApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Data.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {
        protected readonly DataContext _dataContext;

        protected BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public virtual void Add(TEntity entity)
        {
            _dataContext.Add(entity);
            _dataContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dataContext.Update(entity);
            _dataContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _dataContext.Remove(entity);
            _dataContext.SaveChanges();
        }

        public virtual List<TEntity> FindAll()
        {
            return _dataContext.Set<TEntity>().ToList();
        }

        public virtual List<TEntity> Find(Func<TEntity, bool> where)
        {
            return _dataContext.Set<TEntity>().Where(where).ToList();
        }

        public virtual TEntity? FindById(TKey id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public virtual void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
