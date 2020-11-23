using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Pages.events;
using RazorPagesEventMaker.Services;

namespace RazorPagesEventMaker.Pages.events
{
    public class IndexModel : PageModel
    {
        private IRepository repo;
        public List<Event> Events { get; set; }

        [BindProperty(SupportsGet = true)]
        public string Criteria { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime DateFrom { get; set; }

        [BindProperty(SupportsGet = true)]
        public DateTime DateTo { get; set; }

        public IndexModel(IRepository repository)
        {
            DateFrom = DateTime.Now;
            DateTo = DateFrom.AddYears(1);
            repo = repository;
        }

        public void OnGet()
        {
            if (Criteria == null || Criteria == "")
            {
                Events = FiltredDate();
            }
            else
            {
                Events = Filteredevents();
            }
        }

        public void OnPost()
        {

        }

        private List<Event> FiltredDate()
        {
            List<Event> emptyList = new List<Event>();
            foreach (Event e in repo.GetAllEvents())
            {
                if (e.DateTime >= DateFrom && e.DateTime <= DateTo)
                {
                    emptyList.Add(e);
                }
            }
            return emptyList;
        }
        private List<Event> Filteredevents()
        {
            List < Event > datelist = FiltredDate();
            List<Event> emptyList = new List<Event>();
            string criteria = Criteria.ToLower();
            foreach (Event e in datelist)
            {
                if (e.Name.ToLower().Contains(criteria) || e.City.ToLower().Contains(criteria) ||
                    e.Description.ToLower().Contains(criteria))
                    {
                        emptyList.Add(e);
                    }
            }
            return emptyList;
        }
    }
}
