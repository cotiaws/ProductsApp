using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Interface para os métodos de repositório de categoria
    /// </summary>
    public interface ICategoriaRepository : IBaseRepository<Categoria, Guid>
    {

    }
}
