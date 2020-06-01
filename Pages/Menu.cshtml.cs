using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3ClientLATEST.Data;
using SEP3ClientLATEST.Data.dto;

namespace SEP3PresentationTier.Pages
{
    public class Menu : PageModel
    {
        private SEP3BusinessClient _client;

        public Menu(SEP3BusinessClient client)
        {
            _client = client;
        }
        
        [BindProperty]
        public List<ProductDTO> Products { get; set; }
        
        public async Task OnGet()
        {
            Products = await _client.GetMenu();
        }
    }
}