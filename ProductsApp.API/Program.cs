using ProductsApp.API.Extensions;
using ProductsApp.Infra.Data.Extensions;
using ProductsApp.Application.Extensions;
using ProductsApp.Domain.Extensions;
using ProductsApp.Infra.Messages.Extensions;
using ProductsApp.API.Middlewares;
using Prometheus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(config => config.LowercaseUrls = true);
builder.Services.AddSwaggerConfig(); //método de extensão
builder.Services.AddAppServices(); //método de extensão
builder.Services.AddDomainServices(); //método de extensão
builder.Services.AddEntityFramework(builder.Configuration); //método de extensão
builder.Services.AddRabbitMQ(); //método de extensão
builder.Services.AddCorsConfig(builder.Configuration); //método de extensão
builder.Services.AddJwtBearerConfig(builder.Configuration); //método de extensão

var app = builder.Build();

app.UseMiddleware<ErrorLogMiddleware>();

app.UseSwaggerConfig(); //método de extensão
app.UseCorsConfig(); //método de extensão

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

public partial class Program { }