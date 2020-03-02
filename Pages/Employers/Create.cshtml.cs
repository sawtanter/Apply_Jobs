using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Apply_Jobs.Pages.Employers
{
    //Creates an  employer.
    public class CreateModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public CreateModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Gets employer form.
        public IActionResult OnGet()
        {
            return Page();
        }

        //Binds employer model.
        [BindProperty]
        public Employer Employer { get; set; }

        //Adds a employer to databse.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Employer.Add(Employer);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
