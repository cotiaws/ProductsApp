using AutoMapper;
using ProductsApp.Application.Dtos;
using ProductsApp.Application.Interfaces;
using ProductsApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Services
{
    public class CategoriaAppService : ICategoriaAppService
    {
        private readonly ICategoriaService _categoriaService;
        private readonly IMapper _mapper;

        public CategoriaAppService(ICategoriaService categoriaService, IMapper mapper)
        {
            _categoriaService = categoriaService;
            _mapper = mapper;
        }

        public List<CategoriaResponseDto>? Consultar()
        {
            var categorias = _categoriaService.Consultar();
            return _mapper.Map<List<CategoriaResponseDto>>(categorias);
        }
    }
}
