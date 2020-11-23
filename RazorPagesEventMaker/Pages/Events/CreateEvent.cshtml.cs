using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Services;

namespace RazorPagesEventMaker.Pages.events
{
    public class CreateEventModel : PageModel
    {

        private IRepository repo;

        [BindProperty]
        public Event Event { get; set; }

        public CreateEventModel(IRepository repository)
        {
            repo = repository;
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

