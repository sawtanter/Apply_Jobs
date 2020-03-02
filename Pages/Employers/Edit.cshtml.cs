using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Apply_Jobs.Pages.Employers
{
    //Updates rhe employer
    public class EditModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public EditModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Binds employer model.
        [BindProperty]
        public Employer Employer { get; set; }

        //Gets the employer for update using a lamda query.
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

        //Updates the employer.
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Employer).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployerExists(Employer.Id))
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

        //Checks the record for existance.
        private bool EmployerExists(int id)
        {
            return _context.Employer.Any(e => e.Id == id);
        }
    }
}
