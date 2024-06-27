﻿using Draft.Data;
using Draft.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Draft.Controllers
{
    public class PlayerController : Controller
    {

        private readonly DraftContext _context;
        public PlayerController(DraftContext context)
        {
            _context = context;
        }

        public IActionResult Index(string firstName, string lastName, string nationality, int? positionId)
        {
            // Pobierz wszystkie pozycje dla wyszukiwania
            var positions = _context.Positions.ToList();
            ViewData["Positions"] = positions;

            // Pobierz piłkarzy
            var players = _context.Players.Include(p => p.Position).AsQueryable();

            // Filtruj piłkarzy
            if (!string.IsNullOrEmpty(firstName))
            {
                players = players.Where(p => p.FirstName.Contains(firstName));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                players = players.Where(p => p.LastName.Contains(lastName));
            }

            if (!string.IsNullOrEmpty(nationality))
            {
                players = players.Where(p => p.Nationality.Contains(nationality));
            }

            if (positionId.HasValue && positionId > 0)
            {
                players = players.Where(p => p.PositionId == positionId);
            }


            return View(players.ToList());
        }


        public IActionResult Details(int id)
        {
            var player = _context.Players
                                 .Include(p => p.Position)
                                 .FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        public IActionResult EditPlayer(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            var positions = _context.Positions.ToList();
            ViewData["Positions"] = positions;

            if (id == null)
            {
                return NotFound();
            }

            var player = _context.Players.FirstOrDefault(p => p.Id == id);

            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpPost]
        public IActionResult EditPlayer(Player updateplayer)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == updateplayer.Id);

            if (player == null)
            {
                return RedirectToAction("Index", "Home");
            }


            if (ModelState.IsValid)
            {
                player.FirstName = updateplayer.FirstName;
                player.LastName = updateplayer.LastName;
                player.Age = updateplayer.Age;
                player.Height = updateplayer.Height;
                player.ClubName = updateplayer.ClubName;
                player.PositionId = updateplayer.PositionId;
                player.Nationality = updateplayer.Nationality;
                player.PhotoPath = updateplayer.PhotoPath;
                _context.SaveChanges();
                return RedirectToAction("Details", new {id = player.Id});
            }

            var positions = _context.Positions.ToList();
            ViewData["Positions"] = positions;
            return View(updateplayer);
        }


        public IActionResult DeletePlayer(int? id)
        {
            var userRole = HttpContext.Session.GetString("UserRole");
            if (userRole != "Admin")
            {
                return RedirectToAction("Index", "Home");
            }

            if (id == null)
            {
                return NotFound();
            }

            var player = _context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            return View(player);
        }

        [HttpPost]
        public IActionResult DeletePlayer(int id)
        {
            var player = _context.Players.FirstOrDefault(p => p.Id == id);
            if (player == null)
            {
                return NotFound();
            }

            _context.Players.Remove(player);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
