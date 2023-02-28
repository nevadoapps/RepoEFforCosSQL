using Microsoft.EntityFrameworkCore;
using RepoEFCosSQL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoEFCosSQL.Context
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions options) : base(options)
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
