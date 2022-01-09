using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPractice2.Data;
using RazorPagesPractice2.Models;

namespace RazorPagesPractice2.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly MovieContext _context;

        public DeleteModel(MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if(Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FindAsync(id);

            if(Movie != null)
            {
                _context.Movies.Remove(Movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("Index");





        }
    }
}
