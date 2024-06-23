using Draft.Data;
using Draft.Models;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Controllers
{
    public class UserController : Controller
    {
        private readonly DraftContext _context;
        public UserController(DraftContext context)
        {
            _context = context;
        }


        public IActionResult MyProfile()
        {
            var userId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(userId))
            {
                // Redirect to home if user ID is not found in session
                return RedirectToAction("Index", "Home");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);

            if (user == null)
            {
                // Redirect to home if no user found with this ID
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }


        [HttpGet]
        public IActionResult EditProfile()
        {
            var userId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult EditProfile(User updatedUser)
        {
            var userId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            var user = _context.Users.FirstOrDefault(u => u.Id.ToString() == userId);

            if (user == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (_context.Users.Any(u => u.Email == updatedUser.Email && u.Id != user.Id))
            {
                ModelState.AddModelError("Email", "Email already in use.");
            }

            if (_context.Users.Any(u => u.Username == updatedUser.Username && u.Id != user.Id))
            {
                ModelState.AddModelError("Username", "Username already taken.");
            }

            if (ModelState.IsValid)
            {
                user.Email = updatedUser.Email;
                user.Username = updatedUser.Username;
                HttpContext.Session.SetString("Username", user.Username);
                _context.SaveChanges();               
                return RedirectToAction("MyProfile");
            }

            return View(updatedUser);
        }


    }
}
