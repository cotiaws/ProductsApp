using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProductsApp.Domain.Interfaces.Repositories;
using ProductsApp.Infra.Data.Contexts;
using ProductsApp.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Data.Extensions
{
    public static class EntityFrameworkExtension
    {
        /// <summary>
        /// Método de extensão para injeção de dependência e configuração do EntityFramework
        /// </summary>
        public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
        {
            //capturando a connectionstring do arquivo /appsettings.json
            var connectionString = configuration.GetConnectionString("ProductsApp");

            //configurando a injeção de dependência para a classe DataContext
            services.AddDbContext<DataContext>(options => options.UseSqlServer(connectionString));

            //configurando a injeção de dependência para o UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWOrk>();

            return services;
        }
    }
}
