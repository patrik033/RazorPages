using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPractice2.Data;
using RazorPagesPractice2.Models;

namespace RazorPagesPractice2.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MovieContext _context;

        public IndexModel(MovieContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; }
        public IEnumerable<Movie> Movies { get; set; }

        public void OnGet()
        {
            Movies = _context.Movies;
        }
    }
}
