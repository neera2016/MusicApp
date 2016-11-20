using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models
{
    public class Genre
    {
        public int GenreID { get; set; }
        [Required(ErrorMessage = "Genre is required.")]
        [StringLength(20, ErrorMessage = "Genre name has to be less than 20 characters.")]
        public string Name { get; set; }
    }
}
