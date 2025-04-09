using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para a unidade de trabalho do repositório
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        void BeginTransation();
        void Commit();
        void Rollback();

        ICategoriaRepository CategoriaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
    }
}
