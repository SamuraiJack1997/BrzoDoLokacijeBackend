using DemoProjekatAPI.Models;
using LocathorAPI.Models;
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
        public DbSet<Comment> Comments { get; set; }

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
