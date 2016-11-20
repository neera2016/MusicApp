using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        public string Name { get; set; }

        public ApplicationUser user { get; set; }
        public List<PlaylistExtension> list { get; set; }
    }
}
