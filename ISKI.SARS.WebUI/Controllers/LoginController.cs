using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Burada login işlemini yaparsın
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
