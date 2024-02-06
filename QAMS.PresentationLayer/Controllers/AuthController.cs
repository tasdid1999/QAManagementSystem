using Microsoft.AspNetCore.Mvc;
using QAMS.ServiceLayer.authService;
using QAMS.ServiceLayer.ClientEntity;

namespace QAMS.PresentationLayer.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpGet]
        public IActionResult Login()
        {
            ViewBag.WrongCredential = false;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var isSucces = await _authService.LoginAsync(user);

                    if (isSucces)
                    {
                        ModelState.Clear();
                        ViewBag.WrongCredential = false;
                    }
                    else
                    {
                        ViewBag.WrongCredential = true;
                    }
                }
                ViewBag.WrongCredential = false;
                return View(user);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        [HttpGet("register")]
        public IActionResult Register()
        {
            ViewBag.EmailExist = false;
            ViewBag.RegistrationOk = false;

            return View();
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!await _authService.IsEmailExist(user.Email))
                    {
                        var result = await _authService.RegisterAsync(user);
                        if (result)
                        {

                            ModelState.Clear();
                            ViewBag.EmailExist = false;
                            ViewBag.RegistrationOk = true;
                            return View();
                        }
                        else
                        {
                            ViewBag.EmailExist = false;
                            ViewBag.RegistrationOk = false;
                            return View(user);
                        }
                    }
                }

                ViewBag.EmailExist = true;
                ViewBag.RegistrationOk = false;
                return View(user);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
        public async Task<IActionResult> LogoutAsync()
        {
            try
            {
                await _authService.LogOutAsync();
            }
            catch (Exception ex)
            {
                return View(ex);
            }

            return View();
           
        }
    }

   
}
