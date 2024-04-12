using EserEsa.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EserEsa.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OggettoController : Controller
    {
        private readonly OggettoService _service;

        public OggettoController(OggettoService service)
        {
            _service = service;
        }
        // GET: api/<OggettoController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OggettoController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OggettoController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OggettoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OggettoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
