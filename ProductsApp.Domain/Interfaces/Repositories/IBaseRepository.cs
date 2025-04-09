using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface genérica para os métodos de repositório
    /// </summary>
    /// <typeparam name="TEntity">Tipo genérico para as entidades</typeparam>
    /// <typeparam name="TKey">Tipo genérico para os IDs</typeparam>
    public interface IBaseRepository<TEntity, TKey> : IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        List<TEntity> FindAll();
        List<TEntity> Find(Func<TEntity, bool> where);
        TEntity? FindById(TKey id);
    }
}
