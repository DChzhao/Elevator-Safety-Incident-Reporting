using System.ComponentModel.DataAnnotations;

namespace SelftServiceWebApp.Models
{
    public class ElevatorUnit
    {
        [Key]
        public int Id { get; set; }
        public string? UnitId { get; set; }
        public string? StateNumber { get; set; }
        public string? Location { get; set; }
        public string? EquipmentDescription { get; set; }
        public ICollection<Complaint>? Complaints { get; set;}
        
    }
}
