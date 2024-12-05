using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace bigbank.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
