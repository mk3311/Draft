using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Draft.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Team Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Goalkeeper is required.")]
        public int GoalkeeperId { get; set; }
        public Player? Goalkeeper { get; set; }

        [Required(ErrorMessage = "Defender 1 is required.")]
        public int Deffender1Id { get; set; }
        public Player? Deffender1 { get; set; }

        [Required(ErrorMessage = "Defender 2 is required.")]
        public int Deffender2Id { get; set; }
        public Player? Deffender2 { get; set; }

        [Required(ErrorMessage = "Defender 3 is required.")]
        public int Deffender3Id { get; set; }
        public Player? Deffender3 { get; set; }

        [Required(ErrorMessage = "Defender 4 is required.")]
        public int Deffender4Id { get; set; }
        public Player? Deffender4 { get; set; }

        [Required(ErrorMessage = "Midfielder 1 is required.")]
        public int Midfielder1Id { get; set; }
        public Player? Midfielder1 { get; set; }

        [Required(ErrorMessage = "Midfielder 2 is required.")]
        public int Midfielder2Id { get; set; }
        public Player? Midfielder2 { get; set; }

        [Required(ErrorMessage = "Midfielder 3 is required.")]
        public int Midfielder3Id { get; set; }
        public Player? Midfielder3 { get; set; }

        [Required(ErrorMessage = "Midfielder 4 is required.")]
        public int Midfielder4Id { get; set; }
        public Player? Midfielder4 { get; set; }

        [Required(ErrorMessage = "Forward 1 is required.")]
        public int Forward1Id { get; set; }
        public Player? Forward1 { get; set; }

        [Required(ErrorMessage = "Forward 2 is required.")]
        public int Forward2Id { get; set; }
        public Player? Forward2 { get; set; }

        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public ICollection<Favourite> Favourites { get; set; } = new List<Favourite>();
    }
}
