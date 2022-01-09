using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPractice2.Data;
using RazorPagesPractice2.Models;

namespace RazorPagesPractice2.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly MovieContext _context;

        public CreateModel(MovieContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Movie Movie { get; set; }

        public void OnGet()
        {
            
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                await _context.Movies.AddAsync(Movie);
                await _context.SaveChangesAsync();
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
