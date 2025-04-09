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
    public class CategoriaService : ICategoriaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoriaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Categoria>? Consultar()
        {
            return _unitOfWork.CategoriaRepository.FindAll();
        }
    }
}
