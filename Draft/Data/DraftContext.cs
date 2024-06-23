using Draft.Models;
using Microsoft.EntityFrameworkCore;

namespace Draft.Data
{
    public class DraftContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DraftContext(DbContextOptions<DraftContext> options) : base(options) { }
    }
}
