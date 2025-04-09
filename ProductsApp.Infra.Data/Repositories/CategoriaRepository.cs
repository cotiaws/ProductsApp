using ProductsApp.Domain.Interfaces.Repositories;
using ProductsApp.Domain.Models;
using ProductsApp.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Data.Repositories
{
    public class CategoriaRepository : BaseRepository<Categoria, Guid>, ICategoriaRepository
    {
        public CategoriaRepository(DataContext dataContext) : base(dataContext)
        {
            
        }
    }
}
