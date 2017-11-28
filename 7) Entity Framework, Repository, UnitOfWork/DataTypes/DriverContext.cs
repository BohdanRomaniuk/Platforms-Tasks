namespace _7__Entity_Framework__Repository__UnitOfWork.DataTypes
{
    using System;
    using System.Data.Entity;
    using System.Linq;

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