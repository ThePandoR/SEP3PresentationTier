using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3ClientLATEST.Data;
using SEP3ClientLATEST.Data.dto;

namespace SEP3PresentationTier.Pages
{
    public class Register : PageModel
    {
        [BindProperty]
        public RegisterDTO RegisterDto { get; set; }

        private SEP3BusinessClient _client;
        

        public Register(SEP3BusinessClient client)
        {
            _client = client;
        }

        public void OnGet()
        {
        }

        public async Task<ActionResult> OnPost(RegisterDTO registerDto)
        {
            registerDto.type = "CUSTOMER";
            
            var res = await _client.Register(registerDto);

            return RedirectPermanent("/");
        }
    }
}