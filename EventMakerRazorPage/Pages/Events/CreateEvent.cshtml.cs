using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Services;

namespace RazorPagesEventMaker.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        IEventRepository repo;

        [BindProperty]
        public Event Event { get; set; }

        public CreateEventModel(IEventRepository repository)
        {
            repo = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }
    }
}
