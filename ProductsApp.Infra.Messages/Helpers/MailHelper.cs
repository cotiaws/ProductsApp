using Microsoft.Extensions.Configuration;
using ProductsApp.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Infra.Messages.Helpers
{
    public class MailHelper
    {
        private readonly string? _host;
        private readonly int? _port;
        private readonly string? _emailFrom;
        private readonly string? _emailTo;

        public MailHelper(IConfiguration configuration)
        {
            _host = configuration["SmtpSettings:Host"];
            _port = int.Parse(configuration["SmtpSettings:Port"]);
            _emailFrom = configuration["SmtpSettings:EmailFrom"];
            _emailTo = configuration["SmtpSettings:EmailTo"];
        }

        public void Send(LogProdutos log)
        {
            var subject = $"Log de produto gerado com sucesso: {log.Id}";
            var body = @$"
                <div>
                    <h3>ID da transação: {log.Id}</h3>
                    <p><strong>Operação: {log.Operacao}</strong></p>
                    <p>Realizado em: {log.DataHora}</p>
                    <hr/>
                    <h4>Dados do produto:</h4>
                    <p>ID do produto: {log.Produto?.Id}</p>
                    <p>Nome: {log.Produto?.Nome}</p>
                    <p>Preço: {log.Produto?.Preco}</p>
                    <p>Quantidade: {log.Produto?.Quantidade}</p>
                    <p>Categoria: {log.Produto?.Categoria?.Nome}</p>
                </div>
            ";

            var smtpClient = new SmtpClient(_host, _port.Value)
            {
                EnableSsl = false
            };

            var mailMessage = new MailMessage(_emailFrom, _emailTo, subject, body);
            mailMessage.IsBodyHtml = true;

            smtpClient.Send(mailMessage);
        }
    }
}
