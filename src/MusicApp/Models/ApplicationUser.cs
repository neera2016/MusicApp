using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace MusicApp
{
    public class ApplicationUser : IdentityUser
    {
        public DateTime DateJoined { get; set; }
    }
}