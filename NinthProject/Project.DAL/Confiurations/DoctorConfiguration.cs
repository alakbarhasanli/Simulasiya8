using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Confiurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
            .Property(t => t.Name)
            .IsRequired()
            .HasMaxLength(50);
            builder
            .Property(t => t.Department)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}
