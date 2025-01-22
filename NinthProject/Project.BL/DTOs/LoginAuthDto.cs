using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public record LoginAuthDto
    {
        [Display(Prompt = "Username")]
        [Required]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
