using Microsoft.AspNetCore.Mvc;
using xUnit_testing.Models;
using xUnit_testing.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace xUnit_testing.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoopingCartController : ControllerBase
    {
        // GET: api/<ShoppingCartController>

        private readonly IShoopingCartService _service;

        public ShoopingCartController(IShoopingCartService service)
        {
            _service = service;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ShoppingCartController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            var item = _service.GetById(id);
            if (item == null)
            {
                return NotFound();

            }

            return item.Name;
        }


        // POST api/<ShoppingCartController>
        [HttpPost]
        public BadRequestObjectResult Post([FromBody] string value)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var item = _service.Add(value);
            return CreatedAtAction("Get", new { id = item.Id }, item);
        }

        // PUT api/<ShoppingCartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShoppingCartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

    }

}
