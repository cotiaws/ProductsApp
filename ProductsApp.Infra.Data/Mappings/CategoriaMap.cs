using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Data.Mappings
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("CATEGORIA");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id)
                .HasColumnName("ID");

            builder.Property(c => c.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
