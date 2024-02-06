using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.authService
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser<int>> _userManager;
        private readonly SignInManager<IdentityUser<int>> _signInManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;

        public AuthService(UserManager<IdentityUser<int>> userManager,
                          SignInManager<IdentityUser<int>> signInManager,
                          RoleManager<IdentityRole<int>> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public Task<bool> LoginAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> RegisterAsync()
        {
            throw new NotImplementedException();
        }
    }
}
