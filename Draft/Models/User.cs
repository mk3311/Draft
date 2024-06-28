using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Draft.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public UserRole UserRole { get; set; }

        public int? TeamId { get; set; }

        [ForeignKey("TeamId")]
        public Team Team { get; set; }

        public User()
        {
            UserRole = UserRole.User;
        }
    }
}
