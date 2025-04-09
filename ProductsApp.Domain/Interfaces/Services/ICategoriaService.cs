using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Interfaces.Services
{
    public interface ICategoriaService
    {
        List<Categoria>? Consultar();
    }
}
