using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Areas.Register.ViewModels;
using ISKI.SARS.WebUI.Services;

namespace ISKI.SARS.WebUI.Areas.Register.Controllers
{
    [Area("Register")]
    public class RegisterController : Controller
    {
        private readonly IApiService _apiService;

        public RegisterController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool result = await _apiService.RegisterAsync(model);

            if (result)
            {
                return RedirectToAction(
                    "Index",
                    "Login",
                    new { area = "Login", message = "Kayıt başarılı! Yönetici onayı bekleniyor." });
            }

            ModelState.AddModelError(string.Empty, "Kayıt sırasında bir hata oluştu.");
            return View(model);
        }
    }
}
