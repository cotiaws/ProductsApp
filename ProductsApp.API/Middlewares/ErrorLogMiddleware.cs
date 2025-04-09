using Microsoft.AspNetCore.Http;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.API.Middlewares
{
    public class ErrorLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _logDirectory = "Logs";
        private string _logFile => Path.Combine(_logDirectory, $"error-{DateTime.Now:yyyy-MM-dd}.log");

        public ErrorLogMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await LogErrorToFileAsync(context, ex);
                await HandleExceptionAsync(context);
            }
        }

        private async Task LogErrorToFileAsync(HttpContext context, Exception exception)
        {
            if (!Directory.Exists(_logDirectory))
                Directory.CreateDirectory(_logDirectory);

            var log = new StringBuilder();
            log.AppendLine("========== ERRO ==========");
            log.AppendLine($"Data:        {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            log.AppendLine($"StatusCode:  {(int)HttpStatusCode.InternalServerError}");
            log.AppendLine($"Request:     {context.Request.Method} {context.Request.Path}");
            log.AppendLine($"Tipo Erro:   {exception.GetType().FullName}");
            log.AppendLine($"Mensagem:    {exception.Message}");
            log.AppendLine($"StackTrace:  {exception.StackTrace}");
            log.AppendLine("==========================");
            log.AppendLine();

            await File.AppendAllTextAsync(_logFile, log.ToString());
        }

        private Task HandleExceptionAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var result = new
            {
                StatusCode = context.Response.StatusCode,
                Message = "Ocorreu um erro interno no servidor. Consulte os logs para mais detalhes."
            };

            return context.Response.WriteAsJsonAsync(result);
        }
    }
}
