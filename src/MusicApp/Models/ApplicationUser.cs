using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace MusicApp
{
    public class ApplicationUser : IdentityUser
    {
        public string ArtistName { get; set; }
        public DateTime DateJoined { get; set; }
    }
}