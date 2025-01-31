using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Models
{
    public class Produto
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }
        public int? Quantidade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public bool? Ativo { get; set; }
        public Guid? CategoriaId { get; set; }

        #endregion

        #region Propriedades de navegabilidade

        public virtual Categoria? Categoria { get; set; }

        #endregion
    }
}
