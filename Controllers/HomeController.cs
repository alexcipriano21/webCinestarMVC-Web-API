using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webCinestarMVC.Models;

namespace webCinestarMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly dao.daoCine daoCine;
        private readonly dao.daoPelicula daoPelicula;

        public HomeController(IConfiguration config)
        {
            daoCine = new dao.daoCine(config);
            daoPelicula = new dao.daoPelicula(config);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Inicio()
        {
            return View();
        }

        public ActionResult verCines()
        {
            return View(daoCine.getVerCines());
        }

        public ActionResult verCine(int idCine)
        {
            var cine = daoCine.getCine(idCine);
            ViewBag.Cine = cine;
            ViewBag.lstCineTarifas = daoCine.getCineTarifas(idCine);
            ViewBag.lstCinePeliculas = daoCine.getCinePeliculas(idCine);
            return View(cine);
        }

        public ActionResult verPeliculas(int id)
        {
            var lstPeliculas = daoPelicula.getVerPeliculas(id);
            ViewBag.idEstado = id;
            return View(lstPeliculas);
        }

        public ActionResult verPelicula(int idPelicula)
        {
            var pelicula = daoPelicula.getVerPelicula(idPelicula);
            return View(pelicula);
        }
    }
}
