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
            base.Database.EnsureCreated();
        }

        public DbSet<PlayerEntity> Players { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlayerEntity>().HasKey(k => k.Id);
            modelBuilder.Entity<PlayerEntity>().HasPartitionKey(k => k.Id);
            modelBuilder.Entity<PlayerEntity>().ToContainer("Players");
            base.OnModelCreating(modelBuilder);
        }
    }
}
