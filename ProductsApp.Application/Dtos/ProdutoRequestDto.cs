using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Dtos
{
    public class ProdutoRequestDto
    {
        [MaxLength(150, ErrorMessage = "Por favor, informe no máximo {1} caracteres.")]
        [MinLength(8, ErrorMessage = "Por favor, informe no mínimo {1} caracteres.")]
        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Nome { get; set; }

        [Range(0.01, 999999, ErrorMessage = "Por favor, informe o preço entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Range(1, 99999, ErrorMessage = "Por favor, informe a quantidade entre {1} e {2}.")]
        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe o id da categoria.")]
        public Guid? CategoriaId { get; set; }
    }
}

