using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Services
{
    public class FakeEventRepository : IEventRepository
    {
        private List<Event> events { get; }

        public FakeEventRepository()
        {
            events = new List<Event>();
            events.Add(new Event() { Id = 1, Name = "Roskilde Festival", Description = "A lot of music", City = "Roskilde", DateTime = new DateTime(2020, 6, 9, 10, 0, 0) });
            events.Add(new Event() { Id = 2, Name = "CPH Marathon", Description = "Many Marathon runners", City = "Copenhagen", DateTime = new DateTime(2020, 3, 6, 9, 30, 0) });
            events.Add(new Event() { Id = 3, Name = "CPH Distortion", Description = "A lot of beers", City = "Copenhagen", DateTime = new DateTime(2019, 6, 4, 14, 0, 0) });
            events.Add(new Event() { Id = 4, Name = "Demo Day", Description = "Project Presentation", City = "Roskilde", DateTime = new DateTime(2020, 6, 9, 9, 0, 0) });
            events.Add(new Event() { Id = 5, Name = "VM Badminton", Description = "Badminton", City = "Århus", DateTime = new DateTime(2020, 10, 3, 16, 0, 0) });
        }

        public List<Event> GetAllEvents()
        {
            return events.ToList();
        }

        public void AddEvent(Event ev)
        {
            List<int> eventIds = new List<int>();
            foreach (Event evt in events)
            {
                eventIds.Add(evt.Id);
            }
            if (eventIds.Count != 0)
            {
                int start = eventIds.Max();
                ev.Id = start + 1;
            }
            else
            {
                ev.Id = 1;
            }
            events.Add(ev);
        }

        public Event GetEvent(int id)
        {
            foreach (Event toBeEdittedEvent in GetAllEvents())
            {
                if (toBeEdittedEvent.Id == id)
                    return toBeEdittedEvent;
            }

            return new Event();
        }

        public void UpdateEvent(Event @evt)
        {
            if (@evt != null)
            {
                foreach (Event existingEvent in GetAllEvents())
                {
                    if (existingEvent.Id == @evt.Id)
                    {
                        existingEvent.Id = evt.Id;
                        existingEvent.Name = evt.Name;
                        existingEvent.City = evt.City;
                        existingEvent.Description = evt.Description;
                        existingEvent.DateTime = evt.DateTime;
                    }
                }
            }
        }

        public List<Event> FilterEvents(string city)
        {
            List<Event> filteredList = new List<Event>();

            foreach (Event ev in events)
            {
                if (ev.City.Contains(city))
                {
                    filteredList.Add(ev);
                }
            }
            return filteredList;
        }

        public void Delete(int id)
        {
            //Vi tjekker lige at listen ikke er null eller tom - alternativt ville der blive smidt en exception
            if ((events != null) && (events.Count > 0))
            {
                //Her leder vi efter elementet gennem linq
                int c = events.FindIndex(a => a.Id == id);
                events.RemoveAt(events.FindIndex(a => a.Id == id));
            }
        }
    }
}
