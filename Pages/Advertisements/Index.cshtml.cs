using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Apply_Jobs.Pages.Advertisements
{
    //Returns all advertisements.
    public class IndexModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public IndexModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Holds advertisement information.
        public IList<Advertisement> Advertisement { get; set; }

        //Returns all  advertising and employee mapping inoformation using lamda query.
        public void OnGet()
        {
            Advertisement = _context.Advertisement
                .Include(a => a.Employer).ToList();
        }
    }
}
