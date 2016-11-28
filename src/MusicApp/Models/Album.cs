using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models
{
    public class Album
    {
        public int AlbumID { get; set; }

        [Required(ErrorMessage = "Album title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        [Range(.01, 20.00, ErrorMessage = "Price is too high")]
        public decimal Price { get; set; }

        //Foreign key
        public int ArtistID { get; set; }

        //Navigaition property
        public Artist Artist { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }

        public int Like { get; set; }

        public List<PlaylistExtension> List { get; set; }
    }
}
