using LaMafiaRS.Datos;
using LaMafiaRS.Models;
using LaMafiaRS.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using XAct;
using XAct.Library.Settings;

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
            //IEnumerable<Tweet> tweets = _context.Tweet;
            //return View(tweets);

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
                //var consulta = from datos in this._context.User
                //               where datos.Username == tweet.User.Username
                //               select datos.UserId;
                //tweet.UserId = repo.FindUser(tweet.User.Username);


                _context.Add(tweet);
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", tweet);
        }
        
    }
}
