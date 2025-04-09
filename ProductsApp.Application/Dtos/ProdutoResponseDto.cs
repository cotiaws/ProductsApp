using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Dtos
{
    public class ProdutoResponseDto
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public bool? Ativo { get; set; }
        public CategoriaResponseDto? Categoria { get; set; }
    }
}
