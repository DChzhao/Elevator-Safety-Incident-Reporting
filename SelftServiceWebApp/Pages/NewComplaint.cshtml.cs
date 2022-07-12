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

        public List<SelectListItem> ElevatorUnitsOptions { get; set; }

        private int F(int min, int max)
        {
            Random _r = new Random();
            int n = _r.Next(min, max);
            return n;
        }
        /*
        protected void view_Click(object sender, EventArgs e)
        {
            List<int> ints = new List<int>();
            for (int i = 0; i < 10; i++)
            {
               // Random rnd = new Random();
                int randomNumber;
                string strTemp;

                randomNumber = F(1, 30);
                strTemp = (string)Microsoft.VisualBasic.Interaction.Choose(randomNumber, "B", "!", "D", "2", "F", "3", "$", "4", "a", "5", "j", "6", "K", "7", "L", "8", "m", "9", "N", "p", "@", "X", "Y", "#", "G", "H", "%", "R", "w");
                strPassword += strTemp;
                i++;
                Complaint.ConfirmID = strPassword;
            }
        }

        */
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD


      
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            List<int> ints = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                // Random rnd = new Random();
                int randomNumber;
                string strTemp;

                randomNumber = F(1, 30);
                strTemp = (string)Microsoft.VisualBasic.Interaction.Choose(randomNumber, "B", "!", "D", "2", "F", "3", "$", "4", "a", "5", "j", "6", "K", "7", "L", "8", "m", "9", "N", "p", "@", "X", "Y", "#", "G", "H", "%", "R", "w");
                confID += strTemp;
                i++;
                Complaint.ConfirmID = confID;
            }

            */
            DateTime dt = DateTime.Now;
            Complaint.ConfirmID  = string.Format(" CMP{0:yyyyMMddHHmmss}", dt);
           
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
