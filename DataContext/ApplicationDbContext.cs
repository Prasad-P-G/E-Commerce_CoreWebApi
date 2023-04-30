using Ecommerce_Core_WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_Core_WebApi.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext>  options):base(options)
        {
            
        }

        public DbSet<user> Users { get; set; }
    }
}
