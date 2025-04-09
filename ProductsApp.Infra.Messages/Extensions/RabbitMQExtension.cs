using Microsoft.Extensions.DependencyInjection;
using ProductsApp.Application.Interfaces.Messages;
using ProductsApp.Infra.Messages.Consumers;
using ProductsApp.Infra.Messages.Helpers;
using ProductsApp.Infra.Messages.Producers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Messages.Extensions
{
    public static class RabbitMQExtension
    {
        public static IServiceCollection AddRabbitMQ(this IServiceCollection services)
        {
            services.AddTransient<IEventProducer, EventProducer>();
            services.AddTransient<MailHelper>();

            //services.AddHostedService<LogProdutosConsumer>();

            return services;
        }
    }
}
