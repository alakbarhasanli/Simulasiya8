using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public record TreatmentCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        [NotMapped]
        public IFormFile? TreatmentPhoto { get; set; }
    }
}
