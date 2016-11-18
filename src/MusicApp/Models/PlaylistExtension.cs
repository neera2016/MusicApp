using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class PlaylistExtension
    {
        public int playlistID { get; set; }
        public int albumID { get; set; }

        public Playlist playlist { get; set; }
        public Album album { get; set; }
    }
}
