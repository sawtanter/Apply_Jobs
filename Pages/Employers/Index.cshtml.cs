using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Apply_Jobs.Pages.Employers
{
    //Gets all employers 
    public class IndexModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public IndexModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Holds the employers using a linq query.
        public IList<Employer> Employer { get; set; }

        public void OnGet()
        {
            Employer = (from employer in _context.Employer select employer).ToList();
        }
    }
}
