using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;

namespace Apply_Jobs.Pages.Advertisements
{
    //Creats an advertisement.
    public class CreateModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public CreateModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Gets the advertisement create form.
        public IActionResult OnGet()
        {
            ViewData["EmployerId"] = new SelectList(_context.Set<Employer>(), "Id", "Name");
            ViewData["JobType"] = new SelectList(Enum.GetValues(typeof(JobType)));
            return Page();
        }

        //Binds the advertisement model.
        [BindProperty]
        public Advertisement Advertisement { get; set; }

        //Adds an advertisement to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Advertisement.Add(Advertisement);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
