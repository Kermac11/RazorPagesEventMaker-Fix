using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Pages.Countries;

namespace RazorPagesEventMaker.Services
{
    public class FakeEventRepository : IRepository
    {
        private List<Event> _events = new List<Event>();

        public FakeEventRepository()
        {
            _events = new List<Event>();
            _events.Add(new Event()
            {
                Id = 1,
                Name = "Roskilde Festival",
                CountryCode = "DK",
                City = "Roskilde",
                Description = "A lot of music",
                DateTime = new DateTime(2021, 7, 3, 0, 0, 0)
            });
            _events.Add(new Event()
            {
                Id = 2,
                Name = "Paris Marathon",
                CountryCode = "FR",
                City = "Paris",
                Description = "A long exercise run",
                DateTime = new DateTime(2020, 11, 17, 0, 0, 0)
            });

        }


        public void AddEvent(Event ev)
        {
            List<int> eventsIds = new List<int>();

            foreach (var evt in _events)
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
            _events.Add(ev);
        }

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
        public void UpdateEvent(Event Event)
        {
            if (Event != null)
            {
                foreach (Event e in _events)
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
        }

        public List<Event> SearchEventsByCode(string code)
        {
            List<Event> returnlist = new List<Event>();
            foreach (Event ev in _events)
            {
                if (code == ev.CountryCode)
                {
                    returnlist.Add(ev);
                }
            }

            return returnlist;
        }

        public List<Event> GetAllEvents()
        {
            return _events.ToList();
        }
    }

}
