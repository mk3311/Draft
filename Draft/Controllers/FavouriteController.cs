using Draft.Data;
using Draft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Draft.Controllers
{
    public class FavouriteController : Controller
    {
        private readonly DraftContext _context;

        public FavouriteController(DraftContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddFavourite(int teamId)
        {
            var currentUserId = int.Parse(HttpContext.Session.GetString("id"));

            var favourite = new Favourite
            {
                UserId = currentUserId,
                TeamId = teamId
            };

            _context.Favourites.Add(favourite);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFavourite(int teamId)
        {
            var currentUserId = int.Parse(HttpContext.Session.GetString("id"));

            var favourite = _context.Favourites.FirstOrDefault(f => f.UserId == currentUserId && f.TeamId == teamId);
            if (favourite != null)
            {
                _context.Favourites.Remove(favourite);
                await _context.SaveChangesAsync();
            }
            return Ok();
        }


        public IActionResult MyFavourite()
        {
            var userId = HttpContext.Session.GetString("id");

            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }

            var favourites = _context.Favourites.Where(f => f.UserId == int.Parse(userId))
                .Include(f => f.User)
                .Include(f => f.Team);

            var users = _context.Users.ToList();
            ViewData["Users"] = users;
            return View(favourites.ToList());
        }
    }
}
