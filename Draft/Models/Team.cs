using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Draft.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? GoalkeeperId { get; set; }
        [ForeignKey("GoalkeeperId")]
        public Player Goalkeeper { get; set; }

        public int? Deffender1Id { get; set; }
        [ForeignKey("Deffender1Id")]
        public Player Deffender1 { get; set; }

        public int? Deffender2Id { get; set; }
        [ForeignKey("Deffender2Id")]
        public Player Deffender2 { get; set; }

        public int? Deffender3Id { get; set; }
        [ForeignKey("Deffender3Id")]
        public Player Deffender3 { get; set; }

        public int? Deffender4Id { get; set; }
        [ForeignKey("Deffender4Id")]
        public Player Deffender4 { get; set; }

        public int? Midfielder1Id { get; set; }
        [ForeignKey("Midfielder1Id")]
        public Player Midfielder1 { get; set; }

        public int? Midfielder2Id { get; set; }
        [ForeignKey("Midfielder2Id")]
        public Player Midfielder2 { get; set; }

        public int? Midfielder3Id { get; set; }
        [ForeignKey("Midfielder3Id")]
        public Player Midfielder3 { get; set; }

        public int? Midfielder4Id { get; set; }
        [ForeignKey("Midfielder4Id")]
        public Player Midfielder4 { get; set; }

        public int? Forward1Id { get; set; }
        [ForeignKey("Forward1Id")]
        public Player Forward1 { get; set; }

        public int? Forward2Id { get; set; }
        [ForeignKey("Forward2Id")]
        public Player Forward2 { get; set; }
    }
}
