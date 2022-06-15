using Microsoft.EntityFrameworkCore;
using SelftServiceWebApp.Models;

namespace SelftServiceWebApp.Data
{
    public class DbInitializer
    {
        private readonly ModelBuilder modelBuilder;

        public DbInitializer(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
        }

        public void Seed()
        {
            modelBuilder.Entity<ElevatorUnit>().HasData(
                  new ElevatorUnit() { Id=1, Location ="FIU", UnitId ="1"},
                  new ElevatorUnit() { Id=2, Location ="COUNTY", UnitId ="2"}
    
            );
        }
    }
}
