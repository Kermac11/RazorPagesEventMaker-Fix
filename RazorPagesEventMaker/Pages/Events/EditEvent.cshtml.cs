using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesEventMaker.Interfaces;
using RazorPagesEventMaker.Models;
using RazorPagesEventMaker.Services;

namespace RazorPagesEventMaker.Pages.Events
{
    public class EditEventModel : PageModel
    {
        private IRepository repo;
        public EditEventModel(IRepository repository)
        {
            repo = repository;
        }
        [BindProperty]
        public Event Event { get; set; }
        public IActionResult OnGet(int id)
        {
            Event = repo.GetEvents(id);
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repo.UpdateEvent(Event);
            return RedirectToPage("Index");
        }
       


    }
}
