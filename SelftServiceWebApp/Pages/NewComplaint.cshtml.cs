using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelftServiceWebApp.Data;
using SelftServiceWebApp.Models;

namespace SelftServiceWebApp.Pages
{
    public class NewComplaintModel : PageModel
    {
        private readonly SelftServiceWebApp.Data.ApplicationDbContext _context;
        private string? confID;
      
        public NewComplaintModel(SelftServiceWebApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
            
        {
            
        ElevatorUnitsOptions = _context.ElevatorUnits.Select(a =>
                                  new SelectListItem
                                  {
                                      Value = a.Id.ToString(),
                                      Text = a.UnitId + " - " + a.EquipmentDescription,
                                  }).ToList(); 
            return Page();
        }

        [BindProperty]
        public Complaint Complaint { get; set; } = default!;
        [BindProperty]
        [DisplayName("Do you agree to share the contact information? Check the texbox")]
        public bool contInfo { get; set; } = false;

        public List<SelectListItem> ElevatorUnitsOptions { get; set; }

        private int F(int min, int max)
        {
            Random _r = new Random();
            int n = _r.Next(min, max);
            return n;
        }



        public async Task<IActionResult> OnPostAsync()
        {

            DateTime dt = DateTime.Now;
            Complaint.ConfirmID = string.Format(" CMP{0:yyyyMMddHHmmss}", dt);

            if (!ModelState.IsValid || _context.Complaints == null || Complaint == null)
            {
                return Page();
            }

            if (contInfo && (string.IsNullOrEmpty(Complaint.ContactInformation) && string.IsNullOrEmpty(Complaint.Phone)))
            {
                ElevatorUnitsOptions = _context.ElevatorUnits.Select(a =>
                               new SelectListItem
                               {
                                   Value = a.Id.ToString(),
                                   Text = a.UnitId + " - " + a.EquipmentDescription,
                               }).ToList();

                if (string.IsNullOrEmpty(Complaint.ContactInformation) && string.IsNullOrEmpty(Complaint.Phone))
                {
                    ModelState.AddModelError("Complaint.ContactInformation", "Email required");
                    ModelState.AddModelError("Complaint.Phone", "Phone required");
                }

                return Page();
            }


            _context.Complaints.Add(Complaint);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CreatedComplaint", new { ConfirmID = Complaint.ConfirmID});
        }
    }
}
