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
builder.Services.AddSwaggerConfig(); //m�todo de extens�o
builder.Services.AddAppServices(); //m�todo de extens�o
builder.Services.AddDomainServices(); //m�todo de extens�o
builder.Services.AddEntityFramework(builder.Configuration); //m�todo de extens�o
builder.Services.AddRabbitMQ(); //m�todo de extens�o
builder.Services.AddCorsConfig(builder.Configuration); //m�todo de extens�o
builder.Services.AddJwtBearerConfig(builder.Configuration); //m�todo de extens�o

var app = builder.Build();

app.UseMiddleware<ErrorLogMiddleware>();

app.UseSwaggerConfig(); //m�todo de extens�o
app.UseCorsConfig(); //m�todo de extens�o

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.Run();

public partial class Program { }