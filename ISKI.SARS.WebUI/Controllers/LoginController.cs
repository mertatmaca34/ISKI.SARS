using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Models;
using ISKI.SARS.WebUI.Services;
using System.Threading.Tasks;

namespace ISKI.SARS.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IApiService _apiService;

        public LoginController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new LoginViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var result = await _apiService.LoginAsync(model);
                // result => JWT ya da kullanıcı bilgileri
                TempData["LoginResult"] = result;
                return RedirectToAction("Index", "Home");
            }
            catch (HttpRequestException)
            {
                ModelState.AddModelError("", "Sunucuya erişilemedi veya hatalı giriş.");
                return View(model);
            }
        }
    }
}
