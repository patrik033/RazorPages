using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPractice2.Data;
using RazorPagesPractice2.Models;

namespace RazorPagesPractice2.Pages.Movies
{
    public class EditModel : PageModel
    {
        private readonly MovieContext _context;

        public EditModel(MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (Movie == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {

            var update = await _context.Movies.FindAsync(Movie.Id);
            if (update != null)
            {
                update.Title = Movie.Title;
                update.ReleaseDate = Movie.ReleaseDate;
                update.Price = Movie.Price;

                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }

            return RedirectToPage("Index");
        }
    }
}
