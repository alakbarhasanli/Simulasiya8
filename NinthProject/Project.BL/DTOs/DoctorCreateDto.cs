using Microsoft.AspNetCore.Http;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.DTOs
{
    public record DoctorCreateDto
    {
        public string Name { get; set; }
        public string Department { get; set; }
        [NotMapped]
        public IFormFile? DoctorPhoto { get; set; }
        public int TreatmentId { get; set; }
    }
}
