namespace ProductsApp.API.Extensions
{
    /// <summary>
    /// Classe de extensão para configuração do Swagger
    /// </summary>
    public static class SwaggerConfigExtension
    {
        public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }

        public static IApplicationBuilder UseSwaggerConfig(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
