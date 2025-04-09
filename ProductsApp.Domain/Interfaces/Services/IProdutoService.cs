using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Interfaces.Services
{
    public interface IProdutoService
    {
        Produto? Adicionar(Produto? produto);
        Produto? Modificar(Produto? produto);
        Produto? Inativar(Guid? id);

        List<Produto>? Consultar(decimal precoMin, decimal precoMax);
        Produto? ObterPorId(Guid? id);
    }
}
