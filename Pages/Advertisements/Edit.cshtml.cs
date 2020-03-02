using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Apply_Jobs.Pages.Advertisements
{
    //Updates the advertisement.
    public class EditModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public EditModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Binds the advertisement model.
        [BindProperty]
        public Advertisement Advertisement { get; set; }

        //Gets the advertisement for editing. uses a lamda query to select the advert.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = _context.Advertisement
                .Include(a => a.Employer).FirstOrDefault(m => m.Id == id);

            if (Advertisement == null)
            {
                return NotFound();
            }
            ViewData["EmployerId"] = new SelectList(_context.Set<Employer>(), "Id", "Name");
            ViewData["JobType"] = new SelectList(Enum.GetValues(typeof(JobType)));
            return Page();
        }

        //Updates the advertisement 
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Advertisement).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdvertisementExists(Advertisement.Id))
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

        //Uses the lamda to check  the record exists.
        private bool AdvertisementExists(int id)
        {
            return _context.Advertisement.Any(e => e.Id == id);
        }
    }
}
