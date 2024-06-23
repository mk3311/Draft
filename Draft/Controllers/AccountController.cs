using Draft.Data;
using Draft.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Draft.Controllers
{
    public class AccountController : Controller
    {
        private readonly DraftContext _context;
        public AccountController(DraftContext context)
        {
            _context = context;
        }


        // GET: /User/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: /User/Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                // Set session or cookies here
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        // GET: /User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: /User/Register
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }
        //testlol

        // POST: /User/Logout
        [HttpPost]
        public IActionResult Logout()
        {
            // Clear session or cookies here
            return RedirectToAction("Login");
        }

    }
}
