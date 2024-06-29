using Draft.Data;
using Draft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Draft.Controllers
{
    public class TeamController : Controller
    {
        private readonly DraftContext _context;
        public TeamController(DraftContext context)
        {
            _context = context;
        }


        public IActionResult CreateTeam()
        {
            var userId = HttpContext.Session.GetString("id");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }
            var userName = HttpContext.Session.GetString("Username");
            var user = _context.Users.FirstOrDefault(u => u.Username == userName);

            if(user.TeamId != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var players = _context.Players.Include(p => p.Position).ToList();
            ViewData["Players"] = players;
            return View();
        }

        [HttpPost]
        public IActionResult CreateTeam(Team team)
        {

            if (_context.Teams.Any(t => t.Name == team.Name))
            {
                ModelState.AddModelError("Name", "Team Name already in use.");
            }

            if (ModelState.IsValid)
            {
                _context.Teams.Add(team);
                _context.SaveChanges();
                var userName = HttpContext.Session.GetString("Username");
                var user = _context.Users.FirstOrDefault(u => u.Username == userName);
                user.TeamId = team.Id;
                _context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            var players = _context.Players.Include(p => p.Position).ToList();
            ViewData["Players"] = players;
            return View(team);
        }


        public IActionResult DetailsTeam(int idteam)
        {
            var team = _context.Teams
            .Include(t => t.Goalkeeper)
            .Include(t => t.Deffender1)
            .Include(t => t.Deffender2)
            .Include(t => t.Deffender3)
            .Include(t => t.Deffender4)
            .Include(t => t.Midfielder1)
            .Include(t => t.Midfielder2)
            .Include(t => t.Midfielder3)
            .Include(t => t.Midfielder4)
            .Include(t => t.Forward1)
            .Include(t => t.Forward2)
            .FirstOrDefault(t => t.Id == idteam);

            var teamuser = _context.Users.FirstOrDefault(u => u.TeamId == idteam);
            ViewData["TeamUser"] = teamuser;
            return View(team);
        }

    }
}
