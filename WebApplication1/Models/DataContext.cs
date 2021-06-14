using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options)
            : base(options) 
        { }

        public DbSet<Product> Products { get; set; }

    }
}
