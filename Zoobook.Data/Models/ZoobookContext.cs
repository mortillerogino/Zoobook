using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Zoobook.Core.Models;

namespace Zoobook.Data.Models
{
    public class ZoobookContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        public ZoobookContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity => 
                { 
                    entity.Property(e => e.Id).IsRequired();
                });


            modelBuilder.Entity<Employee>().HasData(
            new { Id = 1, FirstName = "Abraham", MiddleName = "the Great Emancipator", LastName = "Lincoln" },
            new { Id = 2, FirstName = "George", MiddleName = "the Founding Father", LastName = "Washington" });
        }
    }
}
