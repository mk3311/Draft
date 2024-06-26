using Draft.Data;
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
    }
}
