using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;


namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
    }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BulkyBookWeb.Models.Company>? Company { get; set; }
        public DbSet<BulkyBookWeb.Models.Product>? Product { get; set; }
        public DbSet<BulkyBookWeb.Models.CoverType>? CoverType { get; set; }
        public DbSet<BulkyBookWeb.Models.OrderDetail>? OrderDetail { get; set; }
        public DbSet<BulkyBookWeb.Models.OrderHeader>? OrderHeader { get; set; }
     
        
       
    }
}
