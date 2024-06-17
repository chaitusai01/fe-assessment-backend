using FeAssignmentApp.Web.API.Models;
using Microsoft.EntityFrameworkCore;

namespace FeAssignmentApp.Web.API.Common
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Patient> Patient { get; set; }
    }
}
