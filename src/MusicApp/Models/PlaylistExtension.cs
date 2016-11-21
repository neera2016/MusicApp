using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class PlaylistExtension
    {
        public int PlaylistID { get; set; }
        public int AlbumID { get; set; }

        public Playlist playlist { get; set; }
        public Album album { get; set; }
    }
}
