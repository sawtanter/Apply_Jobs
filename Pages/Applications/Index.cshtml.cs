using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Apply_Jobs.Pages.Applications
{
    //Returns all applications.
    public class IndexModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public IndexModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Holds all applications.
        public IList<Application> Application { get; set; }

        //Gets all applications using a lamda query.
        public void OnGet()
        {
            Application = _context.Application
                .Include(a => a.Advertisement)
                .Include(a => a.Candidate).Include(a => a.Advertisement.Employer).ToList();
        }
    }
}
