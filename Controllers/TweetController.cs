using LaMafiaRS.Datos;
using LaMafiaRS.Migrations;
using LaMafiaRS.Models;
using LaMafiaRS.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Claims;
using XAct;
using XAct.Library.Settings;
using XAct.Users;

namespace LaMafiaRS.Controllers
{
    public class TweetController : Controller
    {
        private RepositoryWeb repo;
        private ApplicationDbContext _context;

        public TweetController(RepositoryWeb repo, ApplicationDbContext context)
        {
            this.repo = repo;
            this._context = context;

        }
        public IActionResult Index()
        {

            var listarTweets = _context.Tweet.ToList();
            return View(listarTweets);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tweet tweet)
        {
            if (ModelState.IsValid)
            {

                int userId = Convert.ToInt32(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
                Models.User user = new Models.User();
                user.Id = userId;
                tweet.UserId = user.Id;

                _context.Tweet.Add(tweet);
                //_context.Add(tweet);
                
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", tweet);
        }
        
    }
}
