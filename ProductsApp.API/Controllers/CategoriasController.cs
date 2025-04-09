using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Application.Dtos;
using ProductsApp.Application.Interfaces;
using ProductsApp.Domain.Interfaces.Services;

namespace ProductsApp.API.Controllers
{
    //[Authorize(Roles = "Operador, Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private readonly ICategoriaAppService _categoriasAppService;

        public CategoriasController(ICategoriaAppService categoriasAppService)
        {
            _categoriasAppService = categoriasAppService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CategoriaResponseDto>), 200)]
        public IActionResult GetAll()
        {
            return Ok(_categoriasAppService.Consultar());
        }
    }
}
