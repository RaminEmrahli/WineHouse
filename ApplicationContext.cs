using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WineHouse.Entities;

namespace WineHouse
{
    public class ApplicationContext : IdentityDbContext 
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Wine> Wines { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
