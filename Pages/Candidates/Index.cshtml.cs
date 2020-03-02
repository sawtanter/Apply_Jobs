using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace Apply_Jobs.Pages.Candidiates
{
    //Returns all candidates
    public class IndexModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public IndexModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Holds all candidates.
        public IList<Candidate> Candidate { get; set; }

        //Returns all candidates using  a linq query.
        public void OnGet()
        {
            Candidate = (from candidate in _context.Candidate select candidate).ToList();
        }
    }
}
