using LaMafiaRS.Repositories;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using LaMafiaRS.Models;
using XAct.Library.Settings;
using LaMafiaRS.Datos;
using XAct.Users;
using Microsoft.EntityFrameworkCore;

namespace LaMafiaRS.Controllers
{
    public class ManageController : Controller
    {
        private RepositoryWeb repo;
        private ApplicationDbContext _db;

        public ManageController(RepositoryWeb repo, ApplicationDbContext db)
        {
            this.repo = repo;
            this._db = db;
        }
        public IActionResult ListarUsuarios()
        {
            var usuarios = repo.GetUsuarios();
            return View(usuarios);
        }
        public IActionResult Perfil()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult ShowTweets(int id)
        {
            var userProfile = _db.User
                .Include(u => u.Tweets)
                .SingleOrDefault(u => u.Id == id);

            if (userProfile == null)
            {
                return NotFound();
            }

            return View(userProfile);
        }
        [HttpPost]
        public async Task<IActionResult> Perfil(IFormFile profilePicture)
        {
            // Get the file path
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "ProfilePictures", profilePicture.FileName);

            // Save the file to the server
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await profilePicture.CopyToAsync(stream);
            }

            // Update the user's profile picture in the database
            // Update the user's profile picture URL in the database
            int userId = Convert.ToInt32(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var user = _db.User.FirstOrDefault(u => u.Id == userId);
            user.ProfilePictureUrl = "/ProfilePictures/" + profilePicture.FileName;
            _db.User.Update(user);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");

        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            Models.User usuario = this.repo.LogInUsuario(email, password);
            if (usuario == null)
            {
                ViewData["MENSAJE"] = "No tienes credenciales correctas";
                return View();
            }
            else
            {
                ClaimsIdentity identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme, ClaimTypes.Name, ClaimTypes.Role);
                Claim claimUserName = new Claim(ClaimTypes.Name, usuario.Username);
                Claim claimRole = new Claim(ClaimTypes.Role, usuario.Tipo);
                //Claim claimIdUsuario = new Claim("IdUsuario", usuario.Id.ToString());
                Claim claimIdUsuario = new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString());

                Claim claimEmail = new Claim("EmailUsuario", usuario.Email);

                identity.AddClaim(claimUserName);
                identity.AddClaim(claimRole);
                identity.AddClaim(claimIdUsuario);
                identity.AddClaim(claimEmail);

                ClaimsPrincipal userPrincipal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, userPrincipal, new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.Now.AddMinutes(45)
                });

               

                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Search(string buscar)
        {
            var products = from users in _db.User select users;

            if (!String.IsNullOrEmpty(buscar))
            {
                products = products.Where(s => s.Username!.Contains(buscar));
            }

            return View("SearchResults", products.ToList());
        }

        public IActionResult ErrorAcceso()
        {
            ViewData["MENSAJE"] = "Error de acceso";
            return View();
        }
        public async Task<IActionResult> LogOut()
        {
           
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
