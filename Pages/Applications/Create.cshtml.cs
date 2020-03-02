using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Apply_Jobs.Pages.Applications
{
    //Creates an application.
    public class CreateModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public CreateModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }
        //Gets the application form.

        public IActionResult OnGet()
        {
            ViewData["AdvertisementId"] = new SelectList(_context.Advertisement.Include(ad => ad.Employer).ToList(), "Id", "AdvertisementDisplayId");
            ViewData["CandidateId"] = new SelectList(_context.Set<Candidate>(), "Id", "RegsitrationNumber");
            return Page();
        }

        //Bilds the application model.
        [BindProperty]
        public Application Application { get; set; }

        //Adds the application to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Application.Add(Application);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
