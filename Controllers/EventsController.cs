using LaMafiaRS.Datos;
using LaMafiaRS.Filters;
using LaMafiaRS.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using XAct.Library.Settings;

namespace LaMafiaRS.Controllers
{
    public class EventsController : Controller
    {
        private ApplicationDbContext _context;
        public EventsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var listarEventos = _context.Events
                .ToList();
            return View(listarEventos);
        }
        public IActionResult _Eventos()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Events evento)
        {
            if (ModelState.IsValid)
            {
                _context.Events.Add(evento);

                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View("Index", evento);
        }
        [AuthorizeUsers(Policy = "ADMINISTRADORES")]
        public IActionResult Eliminar(int? id)
        {

            var evento = _context.Events.Find(id);
            _context.Events.Remove(evento);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));

        }
    }
}
