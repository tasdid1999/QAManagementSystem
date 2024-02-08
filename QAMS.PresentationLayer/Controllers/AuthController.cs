using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using QAMS.ServiceLayer.authService;
using QAMS.ServiceLayer.ClientEntity.auth;

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
        public async Task<IActionResult> Login(LoginViewModel user, string ReturnUrl = "")
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var roles = await _authService.LoginAsync(user);

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        if (!roles.IsNullOrEmpty())
                        {

                            if (roles[0] == "student")
                            {
                                return RedirectToAction("GetAll", "Student");
                            }
                            else if (roles[0] == "teacher")
                            {
                                return RedirectToAction("GetAll", "Teacher");
                            }
                            else
                            {
                                return RedirectToAction("Login", "Auth");
                            }

                        }
                        else
                        {
                            ViewBag.WrongCredential = true;
                        }
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
        public async Task<IActionResult> Register(RegisterViewModel user)
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
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _authService.LogOutAsync();
                return RedirectToAction("Login","Auth");
            }
            catch (Exception ex)
            {
                return View(ex);
            }

        }
    }

   
}
