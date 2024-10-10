using Microsoft.EntityFrameworkCore;

namespace SignalRApiForMSSQL.DAL
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options):base(options) //Burada appsettings.jsonda tanımlanan connectionString geçilecek.
        {
              
        }
        public DbSet<Visitor> Visitors { get; set; }
    }
}
