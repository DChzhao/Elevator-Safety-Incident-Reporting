using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SelftServiceWebApp.Data;
using SelftServiceWebApp.Models;

namespace SelftServiceWebApp.Pages
{
    public class CreatedComplaint : PageModel
    {
        private readonly ILogger<CreatedComplaint> _logger;
        [BindProperty]
        public string? ConfirmID { get; set; } 
        public CreatedComplaint(ILogger<CreatedComplaint> logger)
        {
            _logger = logger;
        }

        public void OnGet(string ConfirmID)
        {
            this.ConfirmID = ConfirmID;
        }
    }
}