using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using Portfolio.Controllers;
using Portfolio.Models;

namespace Portfolio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=Portfolio;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Projets>().HasOne(i => i.Categorie);
            modelBuilder.Entity<Projets>().HasOne(y => y.Images);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Projets> Projet { get; set; } = null!;

    }
}