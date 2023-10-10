using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.PortableExecutable;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
    }
        public DbSet<Category> Categories { get; set; }
    }
}
