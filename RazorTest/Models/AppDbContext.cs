using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorTest.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }

        public DbSet<Article> Articles { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Fluent API

            modelBuilder.Entity<Article>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Articles)
                    .HasForeignKey(x => x.CategoryId);
            });
        }
    }
}
