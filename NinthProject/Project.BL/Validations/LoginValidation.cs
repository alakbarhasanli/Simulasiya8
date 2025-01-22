using FluentValidation;
using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Validations
{
    public class LoginValidation:AbstractValidator<LoginAuthDto>
    {
        public LoginValidation()
        {
            RuleFor(d => d.Username).NotEmpty().NotNull().WithMessage("Required Username");


            RuleFor(d => d.Password).NotEmpty().NotNull().WithMessage("Required Password");
        }
    }
}
