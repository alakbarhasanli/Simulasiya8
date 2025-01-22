using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class TreatmentValidation:AbstractValidator<TreatmentCreateDto>
    {
        public TreatmentValidation()
        {
            RuleFor(d => d.Name).NotEmpty().NotNull().WithMessage("Required Name").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(d => d.Description).NotEmpty().NotNull().WithMessage("Required Description").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(d => d.TreatmentPhoto).NotEmpty().NotNull().WithMessage("Required Photo");
        }
    }
}
