using Project.BL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Abstractions
{
    public interface IAuthService
    {
        public Task RegisterAsync(RegisterAuthDto dto);
        public Task LoginAsync(LoginAuthDto dto);
        public Task LogoutAsync();
    }
}
