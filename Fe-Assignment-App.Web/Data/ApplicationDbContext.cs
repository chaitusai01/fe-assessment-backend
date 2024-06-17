using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FeAssignmentApp.Web.Models;

namespace FeAssignmentApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Facilities> Facilities { get; set; }
        public DbSet<Patient> Patient { get; set; }
    }
}
