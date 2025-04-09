using Azure;
using Azure.Core;
using Bogus;
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
    public class ProdutosTest : BaseIntegrationHelper
    {
        public ProdutosTest(WebApplicationFactory<Program> factory) : base(factory) { }

        [Fact]
        public async Task Test_Produtos_Post_Returns_Created()
        {
            //consultar as categorias
            var responseCategorias = await _client.GetAsync("api/categorias");
            var categorias = await responseCategorias.Content.ReadFromJsonAsync<List<CategoriaResponseDto>>();

            //criar um produto
            var request = new Faker<ProdutoRequestDto>()
                            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Preco, f => f.Random.Int(0, 99999))
                            .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 999))
                            .RuleFor(p => p.CategoriaId, categorias?.First().Id)
                            .Generate();

            //enviando uma requisição de cadastro do produto
            var response = await _client.PostAsJsonAsync("api/produtos", request);

            //asserção de teste -> verificar se a resposta obteve sucesso (HTTP 200)
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando o retorno da API
            var produto = await response.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //asserções de teste -> dados obtidos devem ser iguais aos dados enviados
            produto?.Id.Should().NotBeNull();
            produto?.Nome.Should().Be(request.Nome);
            produto?.Preco.Should().Be(request.Preco);
            produto?.Quantidade.Should().Be(request.Quantidade);
        }

        [Fact]
        public async Task Test_Produtos_Put_Returns_Ok()
        {
            //consultar as categorias
            var responseCategorias = await _client.GetAsync("api/categorias");
            var categorias = await responseCategorias.Content.ReadFromJsonAsync<List<CategoriaResponseDto>>();

            //criar um produto para cadastro
            var requestCadastro = new Faker<ProdutoRequestDto>()
                            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Preco, f => f.Random.Int(0, 99999))
                            .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 999))
                            .RuleFor(p => p.CategoriaId, categorias?.First().Id)
                            .Generate();

            //enviando uma requisição de cadastro do produto
            var responseCadastro = await _client.PostAsJsonAsync("api/produtos", requestCadastro);

            //capturando o retorno da API
            var produto = await responseCadastro.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //criar um produto para edição
            var requestEdicao = new Faker<ProdutoRequestDto>()
                            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Preco, f => f.Random.Int(0, 99999))
                            .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 999))
                            .RuleFor(p => p.CategoriaId, categorias?.Last().Id)
                            .Generate();

            //enviando uma requisição de edição do produto
            var responseEdicao = await _client.PutAsJsonAsync("api/produtos/" + produto?.Id, requestEdicao);

            //asserção de teste -> verificar se a resposta obteve sucesso (HTTP 200)
            responseEdicao.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando o retorno da API
            var produtoEdicao = await responseEdicao.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //asserções de teste -> dados obtidos devem ser iguais aos dados enviados
            produtoEdicao?.Id.Should().Be(produto?.Id);
            produtoEdicao?.Nome.Should().Be(requestEdicao.Nome);
            produtoEdicao?.Preco.Should().Be(requestEdicao.Preco);
            produtoEdicao?.Quantidade.Should().Be(requestEdicao.Quantidade);
        }

        [Fact]
        public async Task Test_Produtos_Delete_Returns_Ok()
        {
            //consultar as categorias
            var responseCategorias = await _client.GetAsync("api/categorias");
            var categorias = await responseCategorias.Content.ReadFromJsonAsync<List<CategoriaResponseDto>>();

            //criar um produto para cadastro
            var requestCadastro = new Faker<ProdutoRequestDto>()
                            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Preco, f => f.Random.Int(0, 99999))
                            .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 999))
                            .RuleFor(p => p.CategoriaId, categorias?.First().Id)
                            .Generate();

            //enviando uma requisição de cadastro do produto
            var responseCadastro = await _client.PostAsJsonAsync("api/produtos", requestCadastro);

            //capturando o retorno da API
            var produto = await responseCadastro.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //excluindo o produto
            var responseExclusao = await _client.DeleteAsync("api/produtos/" + produto?.Id);

            //asserção de teste -> verificar se a resposta obteve sucesso (HTTP 200)
            responseExclusao.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando o retorno da API
            var produtoExclusao = await responseExclusao.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //asserções de teste -> dados obtidos devem ser iguais aos dados enviados
            produtoExclusao?.Id.Should().Be(produto?.Id);
            produtoExclusao?.Nome.Should().Be(produto?.Nome);
            produtoExclusao?.Preco.Should().Be(produto?.Preco);
            produtoExclusao?.Quantidade.Should().Be(produto?.Quantidade);
        }

        [Fact]
        public async Task Test_Produtos_GetAll_Returns_Ok()
        {
            //consultar as categorias
            var responseCategorias = await _client.GetAsync("api/categorias");
            var categorias = await responseCategorias.Content.ReadFromJsonAsync<List<CategoriaResponseDto>>();

            //criar um produto para cadastro
            var requestCadastro = new Faker<ProdutoRequestDto>()
                            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Preco, f => f.Random.Int(0, 99999))
                            .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 999))
                            .RuleFor(p => p.CategoriaId, categorias?.First().Id)
                            .Generate();

            //enviando uma requisição de cadastro do produto
            var responseCadastro = await _client.PostAsJsonAsync("api/produtos", requestCadastro);

            //capturando o retorno da API
            var produto = await responseCadastro.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //enviando uma requisição de consulta dos produtos
            var responseConsulta = await _client.GetAsync("api/produtos/0/99999");

            //asserção de teste -> verificar se a resposta obteve sucesso (HTTP 200)
            responseConsulta.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando o retorno da API
            var produtosConsulta = await responseConsulta.Content.ReadFromJsonAsync<List<ProdutoResponseDto>>();

            //verificando se dentro da lista está o produto que foi cadastrado
            produtosConsulta?
                .FirstOrDefault(p => p.Id == produto?.Id)
                .Should().NotBeNull();
        }

        [Fact]
        public async Task Test_Produtos_GetById_Returns_Ok()
        {
            //consultar as categorias
            var responseCategorias = await _client.GetAsync("api/categorias");
            var categorias = await responseCategorias.Content.ReadFromJsonAsync<List<CategoriaResponseDto>>();

            //criar um produto para cadastro
            var requestCadastro = new Faker<ProdutoRequestDto>()
                            .RuleFor(p => p.Nome, f => f.Commerce.ProductName())
                            .RuleFor(p => p.Preco, f => f.Random.Int(0, 99999))
                            .RuleFor(p => p.Quantidade, f => f.Random.Int(1, 999))
                            .RuleFor(p => p.CategoriaId, categorias?.First().Id)
                            .Generate();

            //enviando uma requisição de cadastro do produto
            var responseCadastro = await _client.PostAsJsonAsync("api/produtos", requestCadastro);

            //capturando o retorno da API
            var produto = await responseCadastro.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //enviando uma requisição de consulta de produto por id
            var responseConsulta = await _client.GetAsync("api/produtos/" + produto?.Id);

            //asserção de teste -> verificar se a resposta obteve sucesso (HTTP 200)
            responseConsulta.StatusCode.Should().Be(HttpStatusCode.OK);

            //capturando o retorno da API
            var produtosConsulta = await responseConsulta.Content.ReadFromJsonAsync<ProdutoResponseDto>();

            //asserções de teste -> dados obtidos devem ser iguais aos dados enviados
            produtosConsulta?.Id.Should().Be(produto?.Id);
            produtosConsulta?.Nome.Should().Be(produto?.Nome);
            produtosConsulta?.Preco.Should().Be(produto?.Preco);
            produtosConsulta?.Quantidade.Should().Be(produto?.Quantidade);
        }
    }
}
