using Microsoft.Extensions.DependencyInjection;
using ProductsApp.Application.Interfaces;
using ProductsApp.Application.Mappings;
using ProductsApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Extensions
{
    public static class AppServiceExtension
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ProfileMap));

            services.AddTransient<ICategoriaAppService, CategoriaAppService>();
            services.AddTransient<IProdutoAppService, ProdutoAppService>();

            return services;
        }
    }
}
