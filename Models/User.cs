using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PaceWisdomAssignment.Models
{
    public class User
    {
        [Required(ErrorMessage = "Username is required field.")]
        [Display(Name = "Username : ")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required field.")]
        [Display(Name = "Password : ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}