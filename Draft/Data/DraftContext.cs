using Draft.Models;
using Microsoft.EntityFrameworkCore;

namespace Draft.Data
{
    public class DraftContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Player> Players { get; set; }

        public DraftContext(DbContextOptions<DraftContext> options) : base(options) { }
    }
}
