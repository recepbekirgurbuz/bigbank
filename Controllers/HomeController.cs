using System.Diagnostics;
using bigbank.Models;
using Microsoft.AspNetCore.Mvc;

namespace bigbank.Controllers
{
    public class HomeController : Controller
    {
        private readonly BigbankContext _context;

        public HomeController(BigbankContext context)
        {
            _context = context;
        }

        [HttpGet("/")]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            // Oturum kontrolü
            if (HttpContext.Session.GetInt32("Id") == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Username = HttpContext.Session.GetString("Username");
            return View();
        }
    }
}
