using System.Data.Entity;

namespace _7__Entity_Framework__Repository__UnitOfWork.DataTypes
{
    public class DriverContext : DbContext
    {
        public DbSet<TaxiDriver> Drivers { get; set; }
        public DbSet<TaxiClient> Clients { get; set; }
        public DbSet<TaxiOrder> Orders { get; set; }
        public DriverContext(): base("name=DriverContext")
        {
        }
    }
}