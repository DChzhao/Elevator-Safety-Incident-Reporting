using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SelftServiceWebApp.Models
{
    public class Complaint
    {
        [Key]

        [DisplayName("State Serial Number")]
        public string? StateSerialNumber { get; set; }
        [DisplayName("Please enter your email address")]
        public string? ContactInformation { get; set; }
        public string? EquipmentDescription { get; set; }
        public string? Name { get; set; }
        public string? BldgAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public string? ZipCode { get; set; }
        public string? FName { get; set; }
        public string? LName { get; set; }
        public string? Phone { get; set; }




        public int Id { get; set; }
        public DateTime Created { get; set; }

        [DisplayName("Elevator Unit")]
        public int ElevatorUnitId { get; set; }

        public ComplaintType Type { get; set; }

        public string? Description { get; set; }
    
    }


   public enum ComplaintType
    {
        MalFunction,
        [Display(Name ="Not Working")]
        NotWorking,


    }
}
