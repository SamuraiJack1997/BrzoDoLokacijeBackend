using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DemoProjekatAPI.Models
{
    public partial class DemoDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;

        public DemoDbContext() { }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(LocalDb)\LocalDB;Database=DemoDatabase");
            }
        }
    }
}
