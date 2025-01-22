using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class Doctor:BaseEntity
    {
        public string Name { get; set; }
        public string Department { get; set; }
        public string? DoctorImageUrl { get; set; }
        [NotMapped]
        public IFormFile? DoctorPhoto { get; set; }
        public int TreatmentId { get; set; }
        public Treatment treatment { get; set; }
    }
}
