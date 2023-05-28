using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using gerdisc.Models.Validations;

namespace gerdisc.Models.DTOs
{
    public class LoginDto
    {

        [Required(ErrorMessage = "Email is required")]
        [ValidEmail(ErrorMessage = "Email is not in a valid format")]
        public string Email { get; set; } = null!;
        public string Password { get; set; }
    }
}