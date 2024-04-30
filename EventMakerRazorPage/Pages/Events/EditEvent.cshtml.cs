using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Services;

namespace RazorPagesEventMaker.Pages.Events
{
    public class EditEventModel : PageModel
    {
         IEventRepository repo;

        [BindProperty]
        public Event Event { get; set; }

        public EditEventModel(IEventRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvent(id);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repo.UpdateEvent(Event);
            return RedirectToPage("Index");
        }
    }
}
