using Microsoft.Extensions.Logging;
using RazorPagesEventMaker.Helpers;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Services
{
    public class JsonEventRepository : IEventRepository
    {
        private string JsonFileName =
            @"C:\Users\wawer\source\repos\RazorPagesEventMaker\EventMakerRazorPage\Data\JsonEvents.json";

        public List<Event> GetAllEvents()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }

        public void AddEvent(Event evt)
        {
            List<Event> @events = GetAllEvents().ToList();
            List<int> eventIds = new List<int>();
            foreach (Event ev in events)
            {
                eventIds.Add(ev.Id);
            }

            if (eventIds.Count != 0)
            {
                int start = eventIds.Max();
                evt.Id = start + 1;
            }
            else
            {
                evt.Id = 1;
            }
            events.Add(evt);
            JsonFileWriter.WriteToJson(@events, JsonFileName);
        }

        public void UpdateEvent(Event @evt)
        {
            List<Event> @events = GetAllEvents().ToList();
            if (@evt != null)
            {
                foreach (Event existingEvent in events)
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
            JsonFileWriter.WriteToJson(@events, JsonFileName);
        }
        public List<Event> FilterEvents(string city)
        {
            List<Event> @events = GetAllEvents().ToList();
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

        public Event GetEvent(int id)
        {
            List<Event> @events = GetAllEvents().ToList();
            foreach (Event toBeEdittedEvent in events)
            {
                if (toBeEdittedEvent.Id == id)
                    return toBeEdittedEvent;
            }
            return new Event();
        }
        public void Delete(int id)
        {
            List<Event> @events = GetAllEvents().ToList();
                //Her leder vi efter elementet gennem linq
                int c = events.FindIndex(a => a.Id == id);
                events.RemoveAt(c);
            JsonFileWriter.WriteToJson(@events, JsonFileName);
        }
    }
}
