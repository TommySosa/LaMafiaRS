using LaMafiaRS.Datos;
using LaMafiaRS.Models;
using LaMafiaRS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace LaMafiaRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryWeb repo;
        private ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;



        public HomeController(ILogger<HomeController> logger, RepositoryWeb repo, ApplicationDbContext db, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.repo = repo;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registro(string email, string password, string username,DateTime creationdate, string tipo)
        {
            bool registrado = this.repo.RegistrarUsuario(email, password, username,creationdate, tipo);
            if (registrado)
            {
                ViewData["MENSAJE"] = "Usuario registrado con éxito!";
            }
            else
            {
                ViewData["MENSAJE"] = "Error al registrar el usuario";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}