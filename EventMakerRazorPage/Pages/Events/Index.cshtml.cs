using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Services;

namespace RazorPagesEventMaker.Pages.Events
{
    public class IndexModel : PageModel
    {
        IEventRepository repo;

        public List<Event> Events { get; private set; }

        [BindProperty(SupportsGet=true)]
        public string FilterCriteria { get; set; }

        public IndexModel(IEventRepository repository)
        {
            repo = repository;
        }

        public void OnGet()
        {
            Events = repo.GetAllEvents();
            if (!string.IsNullOrEmpty(FilterCriteria))
            {
                Events = repo.FilterEvents(FilterCriteria);
            }
        }
        //Handler til at håndtere sletning
        public IActionResult OnGetDelete(int id)
        {
            repo.Delete(id);
            return RedirectToPage("Index");
        }
    }
}
