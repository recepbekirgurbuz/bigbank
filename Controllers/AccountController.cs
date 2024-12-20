using bigbank.Models;
using Microsoft.AspNetCore.Mvc;

namespace bigbank.Controllers
{
    public class AccountController : Controller
    {
        private readonly BigbankContext _context;

        public AccountController(BigbankContext context)
        {
            _context = context;
        }

        [HttpGet("/login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpGet("/register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet("/details")]
        public IActionResult Details()
        {
            var userId = HttpContext.Session.GetInt32("Id");
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            var customer = _context.Customers.FirstOrDefault(c => c.CustomerId == userId);
            var transaction = _context.Transactions.FirstOrDefault(t => t.TransactionId == userId);
            var account = _context.Accounts.FirstOrDefault(t => t.CustomerId == userId);
            var currentPath = HttpContext.Request.Path;

            var formattedDate = account.CreatedDate?.ToString("dd/MM/yyyy");
            ViewBag.AccountCreatedDate = formattedDate;

            ViewBag.Users = userId;
            ViewBag.CustomerFullName = customer.Name + " " + customer.Surname;
            ViewBag.CustomerID = customer.CustomerId;
            ViewBag.Iban = account.AccountNumber;
            ViewBag.AccountType = account.AccountType;
            ViewBag.AccountBalance = account.Balance;
            
            return View(user);
        }

        [HttpPost("/loginPost")]
        public IActionResult LoginPost(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                HttpContext.Session.SetInt32("Id", user.UserId);
                return RedirectToAction("Home", "Home");
            }

            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı.");
            return View("Login");
        }

        [HttpPost("/registerPost")]
        public IActionResult RegisterPost(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Kayıt başarılı!";
                return RedirectToAction("Login", "Account");
            }

            return View("Register", user);
        }
    }
}
