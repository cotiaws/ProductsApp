using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductsApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
