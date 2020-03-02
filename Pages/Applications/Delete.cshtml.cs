using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Apply_Jobs.Pages.Applications
{
    //Deletes an existing application.
    public class DeleteModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public DeleteModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Binds the application model.
        [BindProperty]
        public Application Application { get; set; }

        //Gets the application for deleting using a lamda query.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = _context.Application
                .Include(a => a.Advertisement)
                .Include(a => a.Candidate).Include(a => a.Advertisement.Employer).FirstOrDefault(m => m.Id == id);

            if (Application == null)
            {
                return NotFound();
            }
            return Page();
        }

        //Removes the application . selects the appplication using a linq query.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Application = (from application in _context.Application
                           where application.Id == id
                           select application).FirstOrDefault();

            if (Application != null)
            {
                _context.Application.Remove(Application);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
