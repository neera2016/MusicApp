using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MusicApp.Models
{
    public class Register
    {
        public int UserID { get; set; }

        [Required(ErrorMessage = "The Email is required.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "The Password is required.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "The Confirm Password is required.")]
        public string ConfirmPassword { get; set; }
    }
}
