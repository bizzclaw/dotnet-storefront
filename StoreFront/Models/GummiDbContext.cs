using System;
using Microsoft.EntityFrameworkCore;

namespace StoreFront.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=StoreFront;uid=root;pwd=root;");
        }

        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
