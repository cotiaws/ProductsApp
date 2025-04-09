using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductsApp.Application.Dtos;
using ProductsApp.Application.Interfaces;

namespace ProductsApp.API.Controllers
{
    //[Authorize(Roles = "Administrador")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ProdutoResponseDto), 200)]
        public IActionResult Post([FromBody] ProdutoRequestDto request)
        {
            return Ok(_produtoAppService.Adicionar(request));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProdutoResponseDto), 200)]
        public IActionResult Put(Guid? id, [FromBody] ProdutoRequestDto request)
        {
            return Ok(_produtoAppService.Modificar(id, request));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProdutoResponseDto), 200)]
        public IActionResult Delete(Guid? id)
        {
            return Ok(_produtoAppService.Inativar(id));
        }

        [HttpGet("{precoMin}/{precoMax}")]
        [ProducesResponseType(typeof(List<ProdutoResponseDto>), 200)]
        public IActionResult Get(decimal precoMin, decimal precoMax)
        {
            return Ok(_produtoAppService.Consultar(precoMin, precoMax));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProdutoResponseDto), 200)]
        public IActionResult GetById(Guid? id)
        {
            return Ok(_produtoAppService.ObterPorId(id));
        }
    }
}
