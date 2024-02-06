using AutoMapper;
using Microsoft.AspNetCore.Identity;
using QAMS.DataAccessLayer.DataContext;
using QAMS.ServiceLayer.ClientEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.authService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager,
                          RoleManager<IdentityRole<int>> roleManager,
                          IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }
        public async Task<bool> LoginAsync(LoginViewModel user)
        {
            var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, false);

            return result.Succeeded ? true : false;
        }

        public async Task<bool> RegisterAsync(RegisterViewModel user)
        {

            var IdentityUser = _mapper.Map<ApplicationUser>(user);

             IdentityUser.UserName = user.Email;

            var result = await _userManager.CreateAsync(IdentityUser, user.Password);

            var userByEmail = await GetUserByEmail(user.Email);

            if (result.Succeeded && userByEmail is not null)
            {
                if (await _roleManager.RoleExistsAsync(user.Role))
                {
                    await _userManager.AddToRoleAsync(userByEmail, user.Role);
                }
                else
                {
                    var role = new IdentityRole<int>(user.Role);
                    
                    if (_roleManager.CreateAsync(role).Result.Succeeded)
                    {
                       return  _userManager.AddToRoleAsync(userByEmail, user.Role).Result.Succeeded ? true : false;
                    }
                    else
                    {
                        return false;
                    }


                }
                
            }
            return result.Succeeded ? true : false;
        }
        public async Task<bool> IsEmailExist(string email)
        {
            var isExist = await _userManager.FindByEmailAsync(email);

            return isExist is not null ? true : false;
        }
        private Task<ApplicationUser?> GetUserByEmail(string email)
        {
            return _userManager.FindByEmailAsync(email);
        }

        public async Task LogOutAsync()
        {
             await _signInManager.SignOutAsync();
        }
    }
}
