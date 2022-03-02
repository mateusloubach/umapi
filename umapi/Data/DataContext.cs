using Microsoft.EntityFrameworkCore;

namespace umapi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Cliente> Membros { get; set; }
    }
}