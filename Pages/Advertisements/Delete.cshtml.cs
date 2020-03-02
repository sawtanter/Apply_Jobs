using Apply_Jobs.BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Apply_Jobs.Pages.Advertisements
{
    //Deletes an advertisement.
    public class DeleteModel : PageModel
    {
        //The databse context.
        private readonly Apply_Jobs.Models.Apply_JobsDatabseContext _context;

        public DeleteModel(Apply_Jobs.Models.Apply_JobsDatabseContext context)
        {
            _context = context;
        }

        //Binds the advertisement model.
        [BindProperty]
        public Advertisement Advertisement { get; set; }

        //Gets the advertisement delete confirmation uses a lamda query to get the advertisement.
        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = _context.Advertisement
                .Include(a => a.Employer).FirstOrDefault(m => m.Id == id);

            if (Advertisement == null)
            {
                return NotFound();
            }
            return Page();
        }
        //Removes the advertisement uses a linq query to get the advertisement.
        public IActionResult OnPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Advertisement = (from advertisement in _context.Advertisement
                             where advertisement.Id == id
                             select advertisement).FirstOrDefault();

            if (Advertisement != null)
            {
                _context.Advertisement.Remove(Advertisement);
                _context.SaveChanges();
            }

            return RedirectToPage("./Index");
        }
    }
}
