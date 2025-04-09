using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using ProductsApp.Application.Models;
using ProductsApp.Infra.Messages.Helpers;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Messages.Consumers
{
    public class LogProdutosConsumer : BackgroundService
    {
        private readonly string? _host;
        private readonly int _port;
        private readonly string? _username;
        private readonly string? _password;
        private readonly string? _vHost;
        private readonly string? _queue;

        private readonly MailHelper? _mailHelper;

        public LogProdutosConsumer(IConfiguration configuration, MailHelper mailHelper)
        {
            _host = configuration["RabbitMQSettings:Host"];
            _port = int.Parse(configuration["RabbitMQSettings:Port"]);
            _username = configuration["RabbitMQSettings:Username"];
            _password = configuration["RabbitMQSettings:Password"];
            _vHost = configuration["RabbitMQSettings:VHost"];
            _queue = configuration["RabbitMQSettings:Queue"];

            _mailHelper = mailHelper;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
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

            //abrindo conexão com o servidor da mensageria
            var connection = connectionFactory.CreateConnection();

            //acessando a fila
            var model = connection.CreateModel();
            model.QueueDeclare(
                queue: _queue, //nome da fila
                durable: true,
                autoDelete: false,
                exclusive: false,
                arguments: null
                );

            //definindo o consumer
            var consumer = new EventingBasicConsumer(model);

            //configurando a interação para leitura da fila
            consumer.Received += (sender, args) =>
            {
                var payload = args.Body.ToArray(); //lendo os dados da fila em bytes
                var message = Encoding.UTF8.GetString(payload); //convertendo para string

                //deserializando os dados da mensagem
                var logProdutos = JsonConvert.DeserializeObject<LogProdutos>(message);

                //enviando o email 
                _mailHelper?.Send(logProdutos);

                //retirando a mensagem da fila
                model.BasicAck(args.DeliveryTag, false);
            };

            //incializando / executando a leitura da fila
            model.BasicConsume(
                queue: _queue,
                autoAck: false,
                consumer: consumer
            );
        }
    }
}
