using Microsoft.EntityFrameworkCore;
using RazorPagesPractice2.Models;

namespace RazorPagesPractice2.Data
{
    public class MovieContext :DbContext
    {

        public MovieContext(DbContextOptions<MovieContext> options) : base(options)
        {


        }
        public DbSet <Movie> Movies { get; set; }

    }
}
