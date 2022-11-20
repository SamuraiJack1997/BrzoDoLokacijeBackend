using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoProjekatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProjekatAPI.Data
{
    public class BrzoDoLokacijeDbContext:DbContext
    {
        public BrzoDoLokacijeDbContext(DbContextOptions<BrzoDoLokacijeDbContext> options) :base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Like>().HasKey(lk => new { lk.postId, lk.userId});

            modelBuilder.Entity<Post>()
                .Property(b => b.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Post>()
                .Property(b => b.Title)
                .IsUnicode(false);
        }
    }
}
