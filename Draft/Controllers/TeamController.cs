using Draft.Data;
using Draft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

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
                ModelState.Clear();
                return RedirectToAction("Index", "Home");
            }
            var players = _context.Players.Include(p => p.Position).ToList();
            ViewData["Players"] = players;
            return View(team);
        }


        public IActionResult DetailsTeam(string idteam)
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
            .FirstOrDefault(t => t.Id == int.Parse(idteam));

            var teamuser = _context.Users.FirstOrDefault(u => u.TeamId == int.Parse(idteam));
            ViewData["TeamUser"] = teamuser;
            return View(team);
        }


        public IActionResult EditTeam()
        {
            var userId = HttpContext.Session.GetString("id");
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index", "Home");
            }
            var userName = HttpContext.Session.GetString("Username");
            var user = _context.Users.FirstOrDefault(u => u.Username == userName);

            if (user.TeamId == null)
            {
                return RedirectToAction("Index", "Home");
            }

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
                        .FirstOrDefault(t => t.Id == user.TeamId);

            var players = _context.Players.Include(p => p.Position).ToList();
            ViewData["Players"] = players;
            return View(team);
        }

        [HttpPost]
        public IActionResult EditTeam(Team updateTeam)
        {
            var team = _context.Teams.FirstOrDefault(t => t.Id == updateTeam.Id);

            if (_context.Teams.Any(t => t.Name == updateTeam.Name && t.Id != updateTeam.Id))
            {
               ModelState.AddModelError("Name", "Team Name already in use.");                              
            }

            if (ModelState.IsValid)
            {
                team.Name = updateTeam.Name;
                team.GoalkeeperId = updateTeam.GoalkeeperId;
                team.Deffender1Id = updateTeam.Deffender1Id;
                team.Deffender2Id = updateTeam.Deffender2Id;
                team.Deffender3Id = updateTeam.Deffender3Id;
                team.Deffender4Id = updateTeam.Deffender4Id;
                team.Midfielder1Id = updateTeam.Midfielder1Id;
                team.Midfielder2Id = updateTeam.Midfielder2Id;
                team.Midfielder3Id = updateTeam.Midfielder3Id;
                team.Midfielder4Id = updateTeam.Midfielder4Id;
                team.Forward1Id = updateTeam.Forward1Id;
                team.Forward2Id = updateTeam.Forward2Id;
                _context.SaveChanges();
                ModelState.Clear();
                return RedirectToAction("DetailsTeam", new { idteam = team.Id.ToString() });
            }
            var players = _context.Players.Include(p => p.Position).ToList();
            ViewData["Players"] = players;
            return View(updateTeam);
        }

    }
}
