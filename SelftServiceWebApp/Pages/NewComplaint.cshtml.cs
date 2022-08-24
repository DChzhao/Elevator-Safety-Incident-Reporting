using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MimeKit;
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



            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Test Project", "dmitriizhao@gmail.com"));
            message.To.Add(new MailboxAddress("Client", Complaint.ContactInformation));
            message.Subject = "Elevator Complaint Test ";
            message.Body = new TextPart("plain")
            {
                Text = "Thank you for using elevetor safety app,\n Your Confirmation ID is: " + Complaint.ConfirmID
            };
            using (var client = new SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);
                client.Authenticate("dmitriizhao@gmail.com", "Password");
               
                client.Send(message);

                client.Disconnect(true);
            }







            return RedirectToPage("./CreatedComplaint", new { ConfirmID = Complaint.ConfirmID});
        }
    }
}
