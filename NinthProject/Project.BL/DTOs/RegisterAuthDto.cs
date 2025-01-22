using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public record RegisterAuthDto
    {
        [Display(Prompt = "Username")]
        [Required]
        public string Username { get; set; }
        [Display(Prompt = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}
