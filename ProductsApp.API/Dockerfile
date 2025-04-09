# Acesse https://aka.ms/customizecontainer para saber como personalizar seu contêiner de depuração e como o Visual Studio usa este Dockerfile para criar suas imagens para uma depuração mais rápida.

# Esta fase é usada durante a execução no VS no modo rápido (Padrão para a configuração de Depuração)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080


# Esta fase é usada para compilar o projeto de serviço
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductsApp.API/ProductsApp.API.csproj", "ProductsApp.API/"]
COPY ["ProductsApp.Application/ProductsApp.Application.csproj", "ProductsApp.Application/"]
COPY ["ProductsApp.Domain/ProductsApp.Domain.csproj", "ProductsApp.Domain/"]
COPY ["ProductsApp.Infra.Data/ProductsApp.Infra.Data.csproj", "ProductsApp.Infra.Data/"]
COPY ["ProductsApp.Infra.Messages/ProductsApp.Infra.Messages.csproj", "ProductsApp.Infra.Messages/"]
RUN dotnet restore "./ProductsApp.API/ProductsApp.API.csproj"
COPY . .
WORKDIR "/src/ProductsApp.API"
RUN dotnet build "./ProductsApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Esta fase é usada para publicar o projeto de serviço a ser copiado para a fase final
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ProductsApp.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Esta fase é usada na produção ou quando executada no VS no modo normal (padrão quando não está usando a configuração de Depuração)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV DOTNET_ENVIRONMENT=Development
ENTRYPOINT ["dotnet", "ProductsApp.API.dll"]