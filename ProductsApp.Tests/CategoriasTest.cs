using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using ProductsApp.Application.Dtos;
using ProductsApp.Tests.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Tests
{
    public class CategoriasTest : BaseIntegrationHelper
    {
        public CategoriasTest(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Test_Categorias_GetAll_Returns_Ok()
        {
            //consultar as categorias da API
            var response = await _client.GetAsync("api/categorias");

            //asserção de teste -> HTTP STATUS OK
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //ler os registros obtidos
            var categorias = await response.Content
                .ReadFromJsonAsync<List<CategoriaResponseDto>>();

            //asserção de teste -> a lista não pode estar vazia
            categorias.Should().NotBeEmpty();
        }
    }
}
