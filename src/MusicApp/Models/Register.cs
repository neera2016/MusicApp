using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Register
    { 
        [Required(ErrorMessage = "The Email is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Artist name is required.")]
        public string ArtistName { get; set; }

        [Required(ErrorMessage = "The Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Password is not the same.")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
