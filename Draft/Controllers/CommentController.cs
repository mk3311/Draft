using Draft.Data;
using Draft.Models;
using Microsoft.AspNetCore.Mvc;

namespace Draft.Controllers
{
    public class CommentController : Controller
    {
        private readonly DraftContext _context;

        public CommentController(DraftContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _context.Users.FirstOrDefault(u => u.Id == comment.UserId);
            var team = _context.Teams.FirstOrDefault(t => t.Id == comment.TeamId);

            if (user == null || team == null)
            {
                return NotFound("User or Team not found.");
            }

            _context.Comments.Add(comment);
            _context.SaveChanges();

            return RedirectToAction("DetailsTeam", "Team", new { idteam = team.Id });
        }

        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            var comment = _context.Comments.FirstOrDefault(c => c.Id == commentId);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("DetailsTeam", "Team", new { idteam = comment.TeamId });
        }
    }
}
