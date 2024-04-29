using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Pages.Events
{
    public class IndexModel : PageModel
    {
        private FakeEventRepository repo;

        public List<Event> Events { get; private set; }

        public IndexModel()
        {
            repo = FakeEventRepository.Instance;
        }

        public void OnGet()
        {
            Events = repo.GetAllEvents();
        }
    }
}
