using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Services;

namespace RazorPagesEventMaker.Pages.events
{
    public class CreateEventModel : PageModel
    {

        private IRepository repo;
        public SelectList CountryCodes { get; set; }
        [BindProperty]
        public Event Event { get; set; }

        public CreateEventModel(IRepository repository, ICountryRepository crepo)
        {
            //repo= FakeEventRepository.Instance;
            repo = repository;
            List<Country> countries = crepo.GetAllCountries();
            CountryCodes = new SelectList(countries, "Code", "Name");

        }



        public IActionResult OnGet()
        {
            return Page();
        }


        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            repo.AddEvent(Event);
            return RedirectToPage("Index");
        }

    }

}

