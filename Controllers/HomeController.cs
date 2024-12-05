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

        [Route("/")]
        public IActionResult Index()
        {
            var users = _context.Users.ToList();
            return View(users);
        }
    }
}
