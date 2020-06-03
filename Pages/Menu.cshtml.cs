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
        
        [BindProperty]
        public string Action { set; get; }
        [BindProperty]
        public string ProductName { set; get; }
        [BindProperty]
        public long ProductId { set; get; }
        [BindProperty]
        public double ProductPrice { get; set; }
        [BindProperty]
        public List<ProductDTO> Products { get; set; }
        
        public Menu(SEP3BusinessClient client)
        {
            _client = client;
        }

        public async Task OnGet()
        {
            Products = await _client.GetMenu();
        }

        public async Task OnPost()
        {
            switch (Action)
            {
                case "Add":
                    await _client.AddProduct(new ProductDTO(ProductName,ProductPrice ));
                    break;
                case "Remove":
                    await _client.RemoveProduct(ProductId);
                    break;
            }
            Products = await _client.GetMenu();
        }
        
    }
}