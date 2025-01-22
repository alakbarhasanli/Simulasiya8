using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.DAL.Enums;
using Project.DAL.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _user;
        private readonly SignInManager<IdentityUser> _sign;

        public AuthService(IMapper mapper, UserManager<IdentityUser> user, SignInManager<IdentityUser> sign)
        {
            _mapper = mapper;
            _user = user;
            _sign = sign;
        }

        public async Task RegisterAsync(RegisterAuthDto dto)
        {
           IdentityUser user=_mapper.Map<IdentityUser>(dto)??throw new BaseException("User Not Found");
            IdentityResult res = await  _user.CreateAsync(user, dto.Password);
            if(!res.Succeeded)
            {
                throw new BaseException("Already Registered");
            }
            res = await _user.AddToRoleAsync(user, Roles.admin.ToString());
            if (!res.Succeeded)
            {
                throw new BaseException("User Have Role");
            }

        }
        public async Task LoginAsync(LoginAuthDto dto)
        {
            IdentityUser user = await _user.FindByNameAsync(dto.Username) ?? throw new BaseException("User Not Found");
            var res=await _sign.PasswordSignInAsync(user, dto.Password,dto.IsPersistent=true,true);
            if (!res.Succeeded)
            {
                throw new BaseException("Already Logined");
            }
        }

        public async Task LogoutAsync()
        {
            await _sign.SignOutAsync();
        }

    }
}
