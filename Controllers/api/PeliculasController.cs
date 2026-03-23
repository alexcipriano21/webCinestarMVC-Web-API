using Microsoft.AspNetCore.Mvc;

namespace webCinestarMVC.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class PeliculasController : ControllerBase
    {
        private readonly dao.daoPelicula _daoPelicula;

        public PeliculasController(IConfiguration config)
        {
            _daoPelicula = new dao.daoPelicula(config);
        }

        [HttpGet("estado/{idEstado}")]
        public IActionResult GetPeliculas(int idEstado)
        {
            var peliculas = _daoPelicula.getPeliculas(idEstado);
            if (peliculas == null || !peliculas.Any()) return NotFound($"No hay películas para el estado {idEstado}.");
            return Ok(peliculas);
        }

        [HttpGet("{id}")]
        public IActionResult GetPelicula(int id)
        {
            var pelicula = _daoPelicula.getPelicula(id);

            if (pelicula == null || pelicula.idPelicula == 0)
            {
                return NotFound(new { mensaje = $"Película con ID {id} no encontrada" });
            }

            return Ok(pelicula);
        }
    }
}
