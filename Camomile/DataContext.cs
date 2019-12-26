using System.Data.Entity;

namespace Camomile
{
    public class DataContext : DbContext
    {
        //Personal note: I could use connection strings in AppConfig
        public DataContext() : base("CamomileDB"){ }

        public DbSet<House> Houses { get; set; }
        public DbSet<ElectriSub> ElectriSubs { get; set; }
    }
}