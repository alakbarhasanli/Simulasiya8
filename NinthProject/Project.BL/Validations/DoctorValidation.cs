using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class DoctorValidation:AbstractValidator<DoctorCreateDto>
    {
        public DoctorValidation()
        {
            RuleFor(d=>d.Name).NotEmpty().NotNull().WithMessage("Required Name").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(d => d.Department).NotEmpty().NotNull().WithMessage("Required Department").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(d => d.DoctorPhoto).NotEmpty().NotNull().WithMessage("Required Photo");
            RuleFor(d => d.TreatmentId).NotEmpty().NotNull().WithMessage("Required Treatment");
        }
    }
}
