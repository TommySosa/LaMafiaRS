using LaMafiaRS.Datos;
using LaMafiaRS.Filters;
using LaMafiaRS.Models;
using LaMafiaRS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Security.Claims;

namespace LaMafiaRS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private RepositoryWeb repo;
        private ApplicationDbContext _db;
        private IWebHostEnvironment _webHostEnvironment;
        private IHubContext<ChatHub> _hubContext;

        public HomeController(ILogger<HomeController> logger, RepositoryWeb repo, ApplicationDbContext db, IWebHostEnvironment webHostEnvironment, IHubContext<ChatHub> hubContext)
        {
            _logger = logger;
            this.repo = repo;
            _db = db;
            _webHostEnvironment = webHostEnvironment;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var listarTweets = _db.Tweet
                .Include(t => t.User)
                .ToList();
            return View(listarTweets);

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
                var tweet = await _db.Tweet.FindAsync(id);

                return PartialView("EditarTweet", tweet);
        }
        [HttpPost]
        public async Task<IActionResult> GuardarCambios(Tweet tweet)
        {
            //Actualizar el tweet en la base de datos
            int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            Models.User user = new Models.User();
            user.Id = userId;
            tweet.UserId = user.Id;
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