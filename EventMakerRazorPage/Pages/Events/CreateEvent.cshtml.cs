using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Pages.Events
{
    public class CreateEventModel : PageModel
    {
        private FakeEventRepository repo;
        [BindProperty]
        public Event Event { get; set; }
        public CreateEventModel()
        {
            repo = new FakeEventRepository();
        }
        public IActionResult OnGet()
        {
            return Page();
        }
        public IActionResult OnPost()
        {
            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }
    }
}
