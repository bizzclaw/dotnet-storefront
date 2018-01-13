using System;
using Microsoft.EntityFrameworkCore;

namespace Gummi.Models
{
    public class GummiDbContext : DbContext
    {
        public GummiDbContext()
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=Gummi;uid=root;pwd=root;");
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
