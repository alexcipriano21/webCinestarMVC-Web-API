using Microsoft.AspNetCore.Mvc;

namespace webCinestarMVC.Controllers.api
{
    [ApiController]
    [Route("api/[controller]")]
    public class CinesController : ControllerBase
    {
        private readonly dao.daoCine _daoCine;

        public CinesController(IConfiguration config)
        {
            _daoCine = new dao.daoCine(config);
        }

        [HttpGet]
        public IActionResult GetCines()
        {
            var cines = _daoCine.getVerCines();
            if (cines == null || !cines.Any()) return NotFound("No hay cines disponibles.");
            return Ok(cines);
        }

        [HttpGet("{id}")]
        public IActionResult GetCine(int id)
        {
            var cine = _daoCine.getCine(id);

            if (cine == null || cine.idCine == 0)
            {
                return NotFound(new { mensaje = $"Cine con ID {id} no encontrado" });
            }

            var cineTarifas = _daoCine.getCineTarifas(id);
            var cinePeliculas = _daoCine.getCinePeliculas(id);

            return Ok(new
            {
                Informacion = cine,
                Tarifas = cineTarifas,
                PeliculasEnCartelera = cinePeliculas
            });
        }
    }
}
