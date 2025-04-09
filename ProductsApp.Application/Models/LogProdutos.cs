using ProductsApp.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Models
{
    public class LogProdutos
    {
        public Guid? Id { get; set; }
        public DateTime? DataHora { get; set; }
        public TipoOperacao? Operacao { get; set; }
        public ProdutoResponseDto? Produto { get; set; }
    }

    public enum TipoOperacao
    {
        Cadastro = 1,
        Edição = 2,
        Exclusão = 3
    }
}
