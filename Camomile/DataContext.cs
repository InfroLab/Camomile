using System.Data.Entity;

namespace Camomile
{
    public class DataContext : DbContext
    {
        //Personal note: I could use connection strings in AppConfig
        public DataContext() : base("CamomileDB"){ }

        public DbSet<User> Users { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}