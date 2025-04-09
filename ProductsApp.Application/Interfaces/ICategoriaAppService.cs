using ProductsApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Interfaces
{
    public interface ICategoriaAppService
    {
        List<CategoriaResponseDto>? Consultar();
    }
}
