using Microsoft.EntityFrameworkCore;

namespace WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Medicines> Medicine { get; set; }
        public DbSet<Clinics> Clinic { get; set; }
    }
}
