﻿using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models
{
    public class Album
    {
        public int AlbumID { get; set; }

        [Required(ErrorMessage = "Album title is required.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Price is required.")]
        public decimal Price { get; set; }

        //Foreign key
        public int ArtistID { get; set; }

        //Navigaition property
        public Artist Artist { get; set; }

        public int GenreID { get; set; }
        public Genre Genre { get; set; }
    }
}
