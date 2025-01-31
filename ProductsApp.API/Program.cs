using ProductsApp.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddRouting(config => config.LowercaseUrls = true);
builder.Services.AddSwaggerConfig(); //método de extensão

var app = builder.Build();

app.UseSwaggerConfig(); //método de extensão
app.UseAuthorization();
app.MapControllers();
app.Run();
