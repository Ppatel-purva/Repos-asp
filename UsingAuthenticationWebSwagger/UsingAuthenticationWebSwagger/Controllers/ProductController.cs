using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UsingAuthenticationWebSwagger.Data;

namespace UsingAuthenticationWebSwagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet, Authorize]
        public IActionResult GetAllProducts()
        {
            var products = ProductStore.GetProducts();
            return Ok(products);

        }
        [HttpGet("{id}")]
        public IActionResult GetProducts(int id)
        {
            var product = ProductStore.GetProduct(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

    }
}
