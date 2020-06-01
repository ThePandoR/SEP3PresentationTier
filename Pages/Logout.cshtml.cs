using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SEP3PresentationTier.Pages
{
    public class Logout : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Clear();

            return RedirectToPage("/Index");
        }
    }
}