using System;
using System.Collections.Generic;
using System.Linq;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Services
{
    public class FakeEventRepository : IRepository
    {
        private List<Event> _events = new List<Event>();

        public FakeEventRepository()
        {
            _events.Add(new Event()
            {
                Id = 1,
                Name = "Roskilde Festival",
                Description = "A lot of music",
                City = "Roskilde",
                DateTime = new DateTime(2020, 12, 9, 10, 0, 0)
            });
            _events.Add(new Event()
            {
                Id = 2,
                Name = "CPH Marahon",
                Description = "Many Marathon runners",
                City = "Copenhagen",
                DateTime = new DateTime(2021, 3, 6, 9, 30, 0)
            });
            _events.Add(new Event()
            {
                Id = 3,
                Name = "CPH Distorsion",
                Description = "A lot of beers",
                City = "Copenhagen",
                DateTime = new DateTime(2010, 11, 4, 14, 0, 0)
            });
            _events.Add(new Event()
            {
                Id = 4,
                Name = "Demo Day",
                Description = "Project Presentation",
                City = "Roskilde",
                DateTime = new DateTime(2020, 12, 24, 9, 0, 0)
            });
            _events.Add(new Event()
            {
                Id = 5,
                Name = "VM Badminton",
                Description = "Badminton",
                City = "Århus",
                DateTime = new DateTime(2020, 12, 30, 16, 0, 0)
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

        public List<Event> GetAllEvents()
        {
            return _events.ToList();
        }
    }

}
