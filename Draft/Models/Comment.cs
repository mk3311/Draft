using System.ComponentModel.DataAnnotations;

namespace Draft.Models
{
    public class Comment
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "UserId is required.")]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Required(ErrorMessage = "TeamId is required.")]
        public int TeamId { get; set; }
        public Team? Team { get; set; }

        [Required]
        [StringLength(1000, ErrorMessage = "Comment cannot be longer than 1000 characters.")]
        public string Content { get; set; }
    }
}
