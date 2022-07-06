using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SelftServiceWebApp.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        public DateTime Created { get; set; }

        [DisplayName("Elevator Unit")]
        public int ElevatorUnitId { get; set; }

        public ComplaintType Type { get; set; }

        public string? Description { get; set; }

        public string? StateSerialNumber { get; set; }
    }


   public enum ComplaintType
    {
        MalFunction,
        [Display(Name ="Not Working")]
        NotWorking,


    }
}
