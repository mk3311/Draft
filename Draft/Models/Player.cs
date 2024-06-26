using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Draft.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        public string Nationality { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public int Height { get; set; }

        [Required]
        [StringLength(100)]
        public string ClubName { get; set; }

        [Required]
        public int PositionId { get; set; }

        // Navigation property
        [ForeignKey("PositionId")]
        public Position Position { get; set; }

        public string PhotoPath { get; set; }
    }
}
