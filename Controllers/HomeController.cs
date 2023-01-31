using LaMafiaRS.Datos;
using LaMafiaRS.Filters;
using LaMafiaRS.Models;
using LaMafiaRS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data;
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
            var listarTweets = _db.Tweet.ToList();
            return View(listarTweets);
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
        [AuthorizeUsers(Policy = "ADMINISTRADORES")]
        public async Task<IActionResult> EditarTweet(int id)
        {
            //Verificar si el usuario es administrador
            //if (User.IsInRole("ADMINISTRADORES"))
            //{
                //Obtener el tweet a editar de la base de datos
                var tweet = await _db.Tweet.FindAsync(id);

                return PartialView("EditarTweet", tweet);
            //}
            //else
            //{
            //    //Redirigir al usuario si no es administrador
            //    return RedirectToAction("Index");
            //}
        }
        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Tweet tweet)
        {
            //Actualizar el tweet en la base de datos
            _db.Update(tweet);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        
        ////editar


        //eliminar
        [AuthorizeUsers(Policy = "ADMINISTRADORES")]
        public IActionResult Eliminar(int? id)
        {

            var tweet = _db.Tweet.Find(id);
            _db.Tweet.Remove(tweet);
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}