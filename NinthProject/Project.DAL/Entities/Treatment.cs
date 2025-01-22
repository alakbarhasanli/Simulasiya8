using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Treatment:BaseEntity
    {
        public string? TreatmentImageUrl { get; set; }
        [NotMapped]
        public IFormFile? TreatmentPhoto { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Doctor> doctors { get; set; }
    }
}
