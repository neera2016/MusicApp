using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MusicApp.Models
{
    public class Playlist
    {
        public int PlaylistID { get; set; }
        [Required(ErrorMessage = "Playlist name required.")]
        public string Name { get; set; }

        public ApplicationUser user { get; set; }
        public List<PlaylistExtension> list { get; set; }
    }
}
