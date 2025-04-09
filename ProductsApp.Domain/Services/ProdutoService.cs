using ProductsApp.Domain.Interfaces.Repositories;
using ProductsApp.Domain.Interfaces.Services;
using ProductsApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductsApp.Domain.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProdutoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Produto? Adicionar(Produto? produto)
        {
            #region Verificar se a categoria não existe

            if (_unitOfWork.CategoriaRepository.FindById(produto.CategoriaId.Value) == null)
                throw new ApplicationException("Categoria não encontrada. Verifique o ID informado.");

            #endregion

            produto.Ativo = true;

            _unitOfWork.ProdutoRepository.Add(produto);

            return produto;
        }

        public Produto? Modificar(Produto? produto)
        {
            #region Verificar se o produto existe

            if (_unitOfWork.ProdutoRepository.FindById(produto.Id.Value) == null)
                throw new ApplicationException("Produto não encontrado. Verifique o ID informado.");

            #endregion

            #region Verificar se a categoria não existe

            if (_unitOfWork.CategoriaRepository.FindById(produto.CategoriaId.Value) == null)
                throw new ApplicationException("Categoria não encontrada. Verifique o ID informado.");

            #endregion

            produto.Ativo = true;

            _unitOfWork.ProdutoRepository.Update(produto);

            return produto;
        }

        public Produto? Inativar(Guid? id)
        {
            #region Verificar se o produto existe

            var produto = _unitOfWork.ProdutoRepository.FindById(id.Value);

            if (produto == null)
                throw new ApplicationException("Produto não encontrado. Verifique o ID informado.");

            #endregion

            produto.Ativo = false;

            _unitOfWork.ProdutoRepository.Update(produto);

            return produto;
        }

        public List<Produto>? Consultar(decimal precoMin, decimal precoMax)
        {
            return _unitOfWork.ProdutoRepository
                    .Find(p => p.Ativo.Value && p.Preco >= precoMin && p.Preco <= precoMax)
                    .OrderByDescending(p => p.Preco)
                    .ToList();
        }

        public Produto? ObterPorId(Guid? id)
        {
            return _unitOfWork.ProdutoRepository
                    .FindById(id.Value);
        }
    }
}
