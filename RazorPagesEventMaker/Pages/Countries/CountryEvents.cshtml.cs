using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;

namespace RazorPagesEventMaker.Pages.Countries
{
    public class CountryEventsModel : PageModel
    {
        private IRepository repo;
        private ICountryRepository _crepo;
        public List<Event> Events { get; private set; }
        public CountryEventsModel(IRepository repository, ICountryRepository crepo)
        {
            repo = repository;
            _crepo = crepo;

        }
        public string ChosenCountry { get; set; }
        public List<Country> Countries { get; private set; }

        public IActionResult OnGet(string code)
        {
            Events = new List<Event>();
            if (code == null)
            {
                return NotFound();
            }
            Events = repo.SearchEventsByCode(code);
            ChosenCountry = _crepo.GetCountryName(code);
            if (Events == null)
            {
                return NotFound();
            }
            return Page();
        }
    }

}
