using AutoMapper;
using ProductsApp.Application.Dtos;
using ProductsApp.Application.Interfaces;
using ProductsApp.Application.Interfaces.Messages;
using ProductsApp.Application.Models;
using ProductsApp.Domain.Interfaces.Services;
using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoService _produtoService;
        private readonly IEventProducer _eventProducer;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoService produtoService, IEventProducer eventProducer, IMapper mapper)
        {
            _produtoService = produtoService;
            _eventProducer = eventProducer;
            _mapper = mapper;
        }

        public ProdutoResponseDto? Adicionar(ProdutoRequestDto request)
        {
            var produto = _mapper.Map<Produto>(request);

            _produtoService.Adicionar(produto);

            var response = _mapper.Map<ProdutoResponseDto>(produto);

            _eventProducer.Publish(new LogProdutos
            {
                Id = Guid.NewGuid(),
                DataHora = DateTime.Now,
                Operacao = TipoOperacao.Cadastro,
                Produto = response,
            });

            return response;
        }

        public ProdutoResponseDto? Modificar(Guid? id, ProdutoRequestDto request)
        {
            var produto = _mapper.Map<Produto>(request);
            produto.Id = id;

            _produtoService.Modificar(produto);

            var response = _mapper.Map<ProdutoResponseDto>(produto);

            _eventProducer.Publish(new LogProdutos
            {
                Id = Guid.NewGuid(),
                DataHora = DateTime.Now,
                Operacao = TipoOperacao.Edição,
                Produto = response,
            });

            return response;
        }

        public ProdutoResponseDto? Inativar(Guid? id)
        {
            var produto = _produtoService.Inativar(id);

            var response = _mapper.Map<ProdutoResponseDto>(produto);

            _eventProducer.Publish(new LogProdutos
            {
                Id = Guid.NewGuid(),
                DataHora = DateTime.Now,
                Operacao = TipoOperacao.Exclusão,
                Produto = response,
            });

            return response;
        }

        public List<ProdutoResponseDto>? Consultar(decimal precoMin, decimal precoMax)
        {
            var produtos = _produtoService.Consultar(precoMin, precoMax);

            return _mapper.Map<List<ProdutoResponseDto>>(produtos);
        }

        public ProdutoResponseDto? ObterPorId(Guid? id)
        {
            var produto = _produtoService.ObterPorId(id);

            return _mapper.Map<ProdutoResponseDto>(produto);
        }
    }
}
