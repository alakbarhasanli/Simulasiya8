using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Confiurations
{
    public class TreatmentConfiguration : IEntityTypeConfiguration<Treatment>
    {
        public void Configure(EntityTypeBuilder<Treatment> builder)
        {
            builder

       .HasMany(e => e.doctors)
       .WithOne(e => e.treatment)
       .HasForeignKey(e => e.TreatmentId)
       .OnDelete(DeleteBehavior.Cascade);

            builder
             .Property(t => t.Name)
             .IsRequired()
             .HasMaxLength(50);

            builder
             .Property(t => t.Name)
             .IsRequired()
             .HasMaxLength(50);
            builder
            .Property(t => t.Description)
            .IsRequired()
            .HasMaxLength(50);


        }
    }
}
