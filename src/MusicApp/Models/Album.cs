using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Album
    {
        public int AlbumID { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }

        //Foreign key
        public int ArtistID { get; set; }

        //Navigaition property
        public Artist Artist { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
