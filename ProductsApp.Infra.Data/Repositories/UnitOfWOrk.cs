using Microsoft.EntityFrameworkCore.Storage;
using ProductsApp.Domain.Interfaces.Repositories;
using ProductsApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Data.Repositories
{
    public class UnitOfWOrk : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWOrk(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        private IDbContextTransaction? _transaction;

        public void BeginTransation()
        {
            _transaction = _dataContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _transaction?.Commit();
        }

        public void Rollback()
        {
            _transaction?.Rollback();
        }

        public ICategoriaRepository CategoriaRepository => new CategoriaRepository(_dataContext);

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(_dataContext);

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
