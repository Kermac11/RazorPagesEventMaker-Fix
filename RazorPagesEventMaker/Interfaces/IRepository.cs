using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Interfaces
{
    public interface IRepository
    {
        List<Event> GetAllEvents();
        Event GetEvents(int id);
        void AddEvent(Event ev);
        void UpdateEvent(Event evt);
        List<Event> SearchEventsByCode(string code);
    }
}
