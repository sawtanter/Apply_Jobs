using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Apply_Jobs.Pages.Employers
{
    //Deletes an employer.
    public class DeleteModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public DeleteModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Binds the employer model.
        [BindProperty]
        public Employer Employer { get; set; }

        //Gets the employer for delete using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employer = _context.Employer.FirstOrDefault(m => m.Id == id);

            if (Employer == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Deletes a employer from databse uses a liq query to get the employer.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Employer = (from employer in _context.Employer
                        where employer.Id == id
                        select employer).FirstOrDefault();

            if (Employer != null)
            {
                _context.Employer.Remove(Employer);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
