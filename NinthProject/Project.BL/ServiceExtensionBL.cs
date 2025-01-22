using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Project.BL.Profiles;
using Project.BL.Services.Abstractions;
using Project.BL.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL
{
    public static class ServiceExtensionBL
    {
        public static void AddServicesBL(this IServiceCollection service)
        {
            service.AddScoped<IAuthService, AuthService>();
            service.AddScoped<IDoctorService, DoctorService>();
            service.AddScoped<ITreatmentService, TreatmentService>();

            service.AddAutoMapper(typeof(AuthProfile).Assembly);
            service.AddAutoMapper(typeof(DoctorProfile).Assembly);
            service.AddAutoMapper(typeof(TreatmentProfile).Assembly);

            service.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            service.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
        }
    }
}
