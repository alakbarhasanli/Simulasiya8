using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class RegisterValidation:AbstractValidator<RegisterAuthDto>
    {
        public RegisterValidation()
        {
            RuleFor(d => d.Username).NotEmpty().NotNull().WithMessage("Required Username").MinimumLength(3).WithMessage("Must be at least 3 chars");
            RuleFor(d => d.Email).NotEmpty().NotNull().WithMessage("Required Email").EmailAddress().WithMessage("Wrong Email Format");
            RuleFor(d => d.Password).NotEmpty().NotNull().WithMessage("Required Password").MinimumLength(6).WithMessage("Must be at least 6 chars");
            RuleFor(d => d.ConfirmPassword).NotEmpty().NotNull().WithMessage("Repeat Password").Equal(p => p.Password).WithMessage("Doesnt Match");

        }
    }
}
