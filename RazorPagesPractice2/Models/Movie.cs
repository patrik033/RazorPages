using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RazorPagesPractice2.Models
{
    public class Movie
    {

        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [DisplayName("Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0,999.999)]
        public decimal Price { get; set; }
    }
}
