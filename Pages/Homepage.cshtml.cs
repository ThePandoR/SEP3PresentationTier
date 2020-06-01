using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SEP3ClientLATEST.Data;
using SEP3ClientLATEST.Data.dto;

namespace SEP3PresentationTier.Pages
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class Homepage : PageModel
    {
        private readonly SEP3BusinessClient _client;

        [BindProperty]
        public string Title { get; set; }
        
        [BindProperty]
        public long VoteId { get; set; }

        [BindProperty]
        public List<SongRequestDTO> Playlist { get; set; }

        public Homepage(SEP3BusinessClient client)
        {
            _client = client;
        }
        
        public async Task<IActionResult> OnGet()
        {

            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                return RedirectToPage("/Index");
            }
            Playlist = await _client.GetPlaylist();
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("username")))
            {
                return RedirectToPage("/Index");
            }
            if (VoteId != 0)
            {
                await _client.Vote(VoteId);
            }
            else
            {
                await _client.Request(new RequestDTO(Title));
            }
            Playlist = await _client.GetPlaylist();
            return Page();
        }
    }
}