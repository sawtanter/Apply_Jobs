﻿using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Apply_Jobs.Pages.Applications
{
    //Updates the application.
    public class EditModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public EditModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Binds the application model.
        [BindProperty]
        public Application Application { get; set; }

        //Gets the application for update using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = _context.Application
                .Include(a => a.Advertisement)
                .Include(a => a.Candidate).FirstOrDefault(m => m.Id == id);

            if (Application == null)
            {
                return NotFound();
            }
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement.Include(ad => ad.Employer).ToList(), "Id", "AdvertisementDisplayId");
            ViewData["CandidateId"] = new SelectList(_context.Set<Candidate>(), "Id", "Id");
            return Page();
        }

        //Updates the application.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Application).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ApplicationExists(Application.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        //Checks for existance of record.
        private bool ApplicationExists(int id)
        {
            return _context.Application.Any(e => e.Id == id);
        }
    }
}
