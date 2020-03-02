using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Apply_Jobs.Pages.Applications
{
    //Gets the details of the application.
    public class DetailsModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public DetailsModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Holds the application.
        public Application Application { get; set; }

        //Gets the application details using a lamda query.
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
    }
}
