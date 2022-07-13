using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SelftServiceWebApp.Models
{
    public class Complaint
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Elevator Unit")]
        public int ElevatorUnitId { get; set; }

        public ComplaintType Type { get; set; }
        [DisplayName("State Serial Number")]
        [Required(ErrorMessage ="This field is required")]
        [RegularExpression("^\\d{5}$", ErrorMessage = "Please enter a valid 5 digits state serial number")]
        public string? StateSerialNumber { get; set; }
       


        [DisplayName("Please enter the building name")]
        [Required(ErrorMessage = "This field is required")]
        public string? BldgName { get; set; }



        [DisplayName("Please enter the building address")]
        [Required(ErrorMessage = "This field is required")]
        public string? BldgAddress { get; set; }



        [Required(ErrorMessage = "This field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please")]
        public string? City { get; set; }



        [Required(ErrorMessage = "This field is required")]
        public string? State { get; set; } = "Fl";



        [Required(ErrorMessage = "This field is required")]
        [RegularExpression("^\\d{5}$", ErrorMessage = "Valid 5 digits zip code must be provided")]
        public string? ZipCode { get; set; }



        [DisplayName("Please enter your email address")]
        [EmailAddress]
        public string? ContactInformation { get; set; }


        [RegularExpression("^\\d{10}$", ErrorMessage = "Valid phone Number must be provided")]
        public string? Phone { get; set; }



        public string? ConfirmID { get; set; } = " asdasd";



  

     

        public string? Description { get; set; }
    
    }

    public enum ComplaintType
    {
        MalFunction,
        [Display(Name ="Not Working")]
        NotWorking,


    }
}
