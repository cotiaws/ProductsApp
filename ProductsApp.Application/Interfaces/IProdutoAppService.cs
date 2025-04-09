using ProductsApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Interfaces
{
    public  interface IProdutoAppService
    {
        ProdutoResponseDto? Adicionar(ProdutoRequestDto request);
        ProdutoResponseDto? Modificar(Guid? id, ProdutoRequestDto request);
        ProdutoResponseDto? Inativar(Guid? id);

        List<ProdutoResponseDto>? Consultar(decimal precoMin, decimal precoMax);
        ProdutoResponseDto? ObterPorId(Guid? id);
    }
}
