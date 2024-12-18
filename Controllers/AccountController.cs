﻿using bigbank.Models;
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

        [HttpPost("/loginPost")]
        public IActionResult LoginPost(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user != null)
            {
                // Oturum bilgilerini saklama
                HttpContext.Session.SetInt32("Id", user.Id);
                HttpContext.Session.SetString("Username", user.Username);

                return RedirectToAction("Index", "Home");
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
