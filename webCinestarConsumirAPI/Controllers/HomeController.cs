using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using webCinestarMVC.Models;

namespace ConsumirApiCinestarWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl = "http://localhost:5121/api/";

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> verPeliculas(string id)
        {
            if (string.IsNullOrEmpty(id) || id == "cartelera") id = "1";
            else if (id == "estrenos") id = "2";

            var response = await _httpClient.GetAsync($"{_apiBaseUrl}peliculas/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var peliculas = JsonSerializer.Deserialize<List<Pelicula>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(peliculas);
            }
            return View(new List<Pelicula>());
        }

        public async Task<IActionResult> verPelicula(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}peliculas/item/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var pelicula = JsonSerializer.Deserialize<Pelicula>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(pelicula);
            }
            return View();
        }

        public async Task<IActionResult> verCines()
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}cines");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var cines = JsonSerializer.Deserialize<List<Cine>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(cines);
            }
            return View(new List<Cine>());
        }

        public async Task<IActionResult> verCine(int id)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}cines/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var root = JsonSerializer.Deserialize<JsonElement>(json);

                var cine = JsonSerializer.Deserialize<Cine>(root.GetProperty("cine").GetRawText(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var tarifas = JsonSerializer.Deserialize<List<CineTarifa>>(root.GetProperty("tarifas").GetRawText(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                var peliculas = JsonSerializer.Deserialize<List<CinePelicula>>(root.GetProperty("peliculas").GetRawText(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                ViewBag.Cine = cine;
                ViewBag.lstCineTarifas = tarifas;
                ViewBag.lstCinePeliculas = peliculas;
                return View();
            }
            return View();
        }
    }
}
