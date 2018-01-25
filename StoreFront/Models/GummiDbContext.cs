using System;
using Microsoft.EntityFrameworkCore;

namespace StoreFront.Models
{
    public class GummiDbContext : DbContext
    {
        public GummiDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=StoreFront;uid=root;pwd=root;");
        }

        public GummiDbContext(DbContextOptions<GummiDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
