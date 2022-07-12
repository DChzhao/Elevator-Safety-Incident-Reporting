using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SelftServiceWebApp.Data;
using SelftServiceWebApp.Models;

namespace SelftServiceWebApp.Pages
{
    public class CreatedComplaint : PageModel
    {
        private readonly ILogger<CreatedComplaint> _logger;
        public string? msg = "hello";
        public string Msg { get { return msg; } }
        public void ID()
        {
            msg = "sad";
        }

        public CreatedComplaint(ILogger<CreatedComplaint> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}