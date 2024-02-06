
using QAMS.ServiceLayer.ClientEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.authService
{
    public interface IAuthService
    {
        Task<bool> LoginAsync(LoginViewModel user);

        Task<bool> RegisterAsync(RegisterViewModel user);

        public Task<bool> IsEmailExist(string email);

        public Task LogOutAsync();

    }
}
