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
                  new ElevatorUnit() { Id=1, EquipmentDescription = "ELECTRIC", UnitId ="1"},
                  new ElevatorUnit() { Id=2, EquipmentDescription = "HYDRAULIC", UnitId ="2"},
                  new ElevatorUnit() { Id = 3, EquipmentDescription = "ESCALATOR", UnitId = "3" },
                  new ElevatorUnit() { Id = 4, EquipmentDescription = "WHEELCHAIR LIFT", UnitId = "4" }


            );
        }
    }
}
