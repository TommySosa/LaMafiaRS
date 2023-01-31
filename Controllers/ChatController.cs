using Microsoft.AspNetCore.Mvc;

namespace LaMafiaRS.Controllers
{
    public class ChatController : Controller
    {
        public static Dictionary<int, string> Rooms =
            new Dictionary<int, string>()
            {
                {1, "Fútbol" },
                {2, "Programación" },
                {3, "Música" },
                {4, "Fiesta" },
                {5, "Memes" }
            };
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Room(int room)
        {
            return View("Room", room);
        }
    }
}
