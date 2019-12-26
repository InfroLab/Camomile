using System.Data.Entity;

namespace Camomile
{
    public class DataContext : DbContext
    {
        //Personal note: I could use connection strings in AppConfig
        public DataContext() : base("CamomileDB"){ }

        public DbSet<House> Houses { get; set; }
        public DbSet<ElectricSub> ElectricSubs { get; set; }
        public DbSet<GasPlant> GasPlants { get; set; }
        public DbSet<Flat> Flats { get; set; }
    }
}