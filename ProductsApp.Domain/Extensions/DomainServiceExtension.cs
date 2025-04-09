using Microsoft.Extensions.DependencyInjection;
using ProductsApp.Domain.Interfaces.Services;
using ProductsApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Extensions
{
    public static class DomainServiceExtension
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IProdutoService, ProdutoService>();

            return services;
        }
    }
}
