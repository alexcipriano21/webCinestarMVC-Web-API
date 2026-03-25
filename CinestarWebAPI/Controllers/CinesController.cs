using Microsoft.AspNetCore.Mvc;
using webCinestarMVC.Controllers.dao;

namespace WebApiCinestar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinesController : ControllerBase
    {
        private readonly daoCine _daoCine;

        public CinesController(IConfiguration configuration)
        {
            _daoCine = new daoCine(configuration);
        }

        [HttpGet]
        public IActionResult GetCines()
        {
            return Ok(_daoCine.getVerCines());
        }

        [HttpGet("{id}")]
        public IActionResult GetCine(int id)
        {
            var cine = _daoCine.getCine(id);
            var tarifas = _daoCine.getCineTarifas(id);
            var peliculas = _daoCine.getCinePeliculas(id);
            
            return Ok(new {
                Cine = cine,
                Tarifas = tarifas,
                Peliculas = peliculas
            });
        }
    }
}
