using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Models
{
    public class Categoria
    {
        #region Propriedades

        public Guid? Id { get; set; }
        public string? Nome { get; set; }

        #endregion

        #region Propriedades de navegabilidade

        public virtual ICollection<Produto>? Produtos { get; set; }

        #endregion
    }
}
