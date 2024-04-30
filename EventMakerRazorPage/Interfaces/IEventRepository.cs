using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Interfaces
{
    public interface IEventRepository
    {
        List<Event> GetAllEvents();

        Event GetEvent(int id);

        void AddEvent(Event ev);

        void UpdateEvent(Event evt);

        List<Event> FilterEvents(String city);

        void Delete(int id);


    }
}
