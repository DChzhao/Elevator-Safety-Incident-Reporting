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
        [DisplayName("Please enter the building name")]
        public string? BldgName { get; set; }
        [DisplayName("Please enter the building address")]
        public string? BldgAddress { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }

        public string? ZipCode { get; set; }
  
        public string? Phone { get; set; }


        public string? ConfirmID { get; set; } = " asdasd";


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
