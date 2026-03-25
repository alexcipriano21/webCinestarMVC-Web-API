using Microsoft.AspNetCore.Mvc;
using webCinestarMVC.Controllers.dao;

namespace WebApiCinestar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly daoPelicula _daoPelicula;

        public PeliculasController(IConfiguration configuration)
        {
            _daoPelicula = new daoPelicula(configuration);
        }

        [HttpGet("{id}")]
        public IActionResult GetPeliculas(int id)
        {
            var peli = _daoPelicula.getVerPeliculas(id);
            return Ok(peli);
        }

        [HttpGet("item/{idPelicula}")]
        public IActionResult GetPelicula(int idPelicula)
        {
            var peli = _daoPelicula.getVerPelicula(idPelicula);
            return Ok(peli);
        }
    }
}
