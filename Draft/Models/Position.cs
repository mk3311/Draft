using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Draft.Models
{
    public class Position
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Player> Players { get; set; }
    }
}
