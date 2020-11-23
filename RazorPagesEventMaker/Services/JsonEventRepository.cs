using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RazorPagesEventMaker.Helpers;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Services
{
    public class JsonEventRepository : IRepository
    {

        public Event GetEvents(int id)
        {
            foreach (var v in GetAllEvents())
            {
                if (v.Id == id)
                {
                    return v;
                }
            }

            return new Event();
        }

        public void AddEvent(Event ev)
        {
            List<int> eventsIds = new List<int>();
            List<Event> events = GetAllEvents();
            foreach (var evt in events)
            {
                eventsIds.Add(evt.Id);
            }

            if (eventsIds.Count != 0)
            {
                int start = eventsIds.Max();
                ev.Id = start + 1;
            }
            else
            {
                ev.Id = 1;
            }
            events.Add(ev);
            JsonFileWriter.WriteToJson(events, filePath);
        }

        public void UpdateEvent(Event Event)
        {
            List<Event> events = GetAllEvents();
            if (Event != null)
            {
                foreach (Event e in events )
                {
                    if (e.Id == Event.Id)
                    {
                        e.Id = Event.Id;
                        e.Name = Event.Name;
                        e.City = Event.City;
                        e.Description = Event.Description;
                        e.DateTime = Event.DateTime;
                    }
                }
            }
            JsonFileWriter.WriteToJson(events, filePath);
        }

        public List<Event> SearchEventsByCode(string code)
        {
            throw new NotImplementedException();
        }

        //private string filePath = "C:\\Users\\mtyge\\OneDrive\\Documents\\SWC\\Mine Programmer\\RazorPages\\RazorPagesEventMaker\\RazorPagesEventMaker\\Services\\JsonEventRepository.cs";
        private string filePath = @"Data\jsonEvents.json";
        public List<Event> GetAllEvents()
        {
            return JsonFileReader.ReadJson(filePath);
        }

    }
}
