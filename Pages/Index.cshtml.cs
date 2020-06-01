using System.Security.Authentication;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3ClientLATEST.Data;
using SEP3ClientLATEST.Data.dto;

namespace SEP3PresentationTier.Pages
{
    public class IndexModel : PageModel
    {   
        [BindProperty]
        public LoginDTO LoginDto { get; set; }

        private readonly SEP3BusinessClient _client;
        

        public IndexModel(SEP3BusinessClient client)
        {
            _client = client;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(LoginDTO loginDto)
        {

            try
            {
                var res = await _client.Login(loginDto); 
                
                HttpContext.Session.SetString("username",res.username);
                HttpContext.Session.SetString("userid", $"{res.id}");

                return RedirectToPage("./Homepage");
            }
            catch (AuthenticationException e)
            {
                ViewData["error"] = "Username or password invalid";

                return Page();
            }
        }
    }
}