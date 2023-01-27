using LaMafiaRS.Datos;
using LaMafiaRS.Models;
using LaMafiaRS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> Editar(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }
            else
            {

                var producto = await _db.Tweet.FindAsync(id);
                if (producto == null)
                {
                    return NotFound();
                }
                else
                {
                    return View(producto);
                }

            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Editar(int id, [Bind("TweetId,Text,CreationDate")] Tweet objTweet)
        {

            if (id != objTweet.TweetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(objTweet);
                    await _db.SaveChangesAsync();

                }
                catch (DbUpdateConcurrencyException)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }

            return View(objTweet);

        }
        //editar


        //eliminar
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