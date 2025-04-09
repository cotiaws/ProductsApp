using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductsApp.Application.Interfaces.Messages;
using ProductsApp.Application.Models;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Messages.Producers
{
    public class EventProducer : IEventProducer
    {
        private readonly string? _host;
        private readonly int _port;
        private readonly string? _username;
        private readonly string? _password;
        private readonly string? _vHost;
        private readonly string? _queue;

        public EventProducer(IConfiguration configuration)
        {
            _host = configuration["RabbitMQSettings:Host"];
            _port = int.Parse(configuration["RabbitMQSettings:Port"]);
            _username = configuration["RabbitMQSettings:Username"];
            _password = configuration["RabbitMQSettings:Password"];
            _vHost = configuration["RabbitMQSettings:VHost"];
            _queue = configuration["RabbitMQSettings:Queue"];
        }

        public void Publish(LogProdutos log)
        {
            //Configurando os parâmetros para conexão com o servidor do RabbitMQ
            var connectionFactory = new ConnectionFactory
            {
                HostName = _host, //endereço do servidor
                Port = _port, //porta do servidor
                UserName = _username, //usuário do rabbitmq
                Password = _password, //senha do usuário do rabbitmq
                VirtualHost = _vHost, //endereço do host virtual
            };

            //Abrindo conexão com o servidor do RabbitMQ
            using (var connection = connectionFactory.CreateConnection())
            {
                //Criando a fila e gravar a mensagem
                using (var model = connection.CreateModel())
                {
                    //Criando a fila caso não exista
                    model.QueueDeclare(
                        queue: _queue, //nome da fila
                        durable: true, //fila não será apagada caso o servidor seja parado
                        autoDelete: false, //a fila não exclui mensagens automaticamente
                        exclusive: false, //a fila poderá ser compartilhada com outras aplicações
                        arguments: null
                        );

                    //Serializando os dados do log para JSON
                    var json = JsonConvert.SerializeObject(log);

                    //Gravar os dados na fila
                    model.BasicPublish(
                        exchange: string.Empty,
                        routingKey: _queue,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(json)
                        );
                }
            }
        }
    }
}
