using Microsoft.AspNetCore.Mvc;

namespace QAMS.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult AccessDenied(string ReturnUrl)
        {
            return RedirectToAction("Login", "Auth", new {ReturnUrl = ReturnUrl});
        }
    }
}
