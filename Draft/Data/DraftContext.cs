using Draft.Models;
using Microsoft.EntityFrameworkCore;

namespace Draft.Data
{
    public class DraftContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        public DraftContext(DbContextOptions<DraftContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Konfiguracja relacji w modelu Team
            modelBuilder.Entity<Team>()
                .HasOne(t => t.Goalkeeper)
                .WithMany()
                .HasForeignKey(t => t.GoalkeeperId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Deffender1)
                .WithMany()
                .HasForeignKey(t => t.Deffender1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Deffender2)
                .WithMany()
                .HasForeignKey(t => t.Deffender2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Deffender3)
                .WithMany()
                .HasForeignKey(t => t.Deffender3Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Deffender4)
                .WithMany()
                .HasForeignKey(t => t.Deffender4Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Midfielder1)
                .WithMany()
                .HasForeignKey(t => t.Midfielder1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Midfielder2)
                .WithMany()
                .HasForeignKey(t => t.Midfielder2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Midfielder3)
                .WithMany()
                .HasForeignKey(t => t.Midfielder3Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Midfielder4)
                .WithMany()
                .HasForeignKey(t => t.Midfielder4Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Forward1)
                .WithMany()
                .HasForeignKey(t => t.Forward1Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Team>()
                .HasOne(t => t.Forward2)
                .WithMany()
                .HasForeignKey(t => t.Forward2Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasOne(u => u.Team)
                .WithOne()
                .HasForeignKey<User>(u => u.TeamId)
                .OnDelete(DeleteBehavior.SetNull);
        }


    }
}
