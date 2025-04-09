using Microsoft.EntityFrameworkCore;
using ProductsApp.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Data.Contexts
{
    public class DataContext : DbContext
    {
        /// <summary>
        /// Construtor para injeção de dependência
        /// </summary>
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        /// <summary>
        /// Método para adicionarmos as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }
    }
}
