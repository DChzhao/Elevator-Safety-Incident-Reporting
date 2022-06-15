using System;
using System.Collections.Generic;
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
                                      Text = a.UnitId + " - " + a.Location,
                                  }).ToList(); 
            return Page();
        }

        [BindProperty]
        public Complaint Complaint { get; set; } = default!;

        public List<SelectListItem> ElevatorUnitsOptions { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Complaints == null || Complaint == null)
            {
                return Page();
            }

            _context.Complaints.Add(Complaint);
            await _context.SaveChangesAsync();

            return RedirectToPage("./CreatedComplaint");
        }
    }
}
