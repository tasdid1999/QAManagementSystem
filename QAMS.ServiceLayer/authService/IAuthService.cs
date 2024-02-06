using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAMS.ServiceLayer.authService
{
    public interface IAuthService
    {
        Task<bool> LoginAsync();

        Task<bool> RegisterAsync();

    }
}
