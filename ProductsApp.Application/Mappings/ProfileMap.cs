using AutoMapper;
using ProductsApp.Application.Dtos;
using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Mappings
{
    /// <summary>
    /// Classe para configurações de mapeamento do AutoMapper
    /// </summary>
    public class ProfileMap : Profile
    {
        public ProfileMap()
        {
            CreateMap<ProdutoRequestDto, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.Id = Guid.NewGuid();
                    dest.DataHoraCadastro = DateTime.Now;
                    dest.Ativo = true;
                });

            CreateMap<Produto, ProdutoResponseDto>();

            CreateMap<Categoria, CategoriaResponseDto>();
        }
    }
}
