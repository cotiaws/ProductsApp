using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para os métodos de repositório de produto
    /// </summary>
    public interface IProdutoRepository : IBaseRepository<Produto, Guid>
    {

    }
}
