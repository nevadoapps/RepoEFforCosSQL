using Microsoft.EntityFrameworkCore;
using RepoEFCosSQLWeb.Entities;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace RepoEFCosSQLWeb.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LevelEntity> Levels { get; set; }
        public DbSet<PlayerEntity> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LevelEntity>()
                .HasOne(h => h.Player)
                .WithMany(m => m.Levels)
                .HasForeignKey(p => p.Id);

            base.OnModelCreating(modelBuilder);
        }
    }
}
