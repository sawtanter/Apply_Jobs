using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apply_Jobs.Pages.Candidiates
{
    //Adds a candidate 
    public class CreateModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public CreateModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Gets the candidate form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds the cadidate model.
        [BindProperty]
        public Candidate Candidate { get; set; }

        //Adds  a candidate to database.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Candidate.Add(Candidate);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
