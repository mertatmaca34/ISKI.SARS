using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.WebUI.Controllers
{
    public class UserInfoController : Controller
    {
        private readonly IApiService _apiService;

        public UserInfoController(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var token = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
            {
                ViewBag.ErrorMessage = "Kullanıcı oturumu bulunamadı. Lütfen tekrar giriş yapınız.";
                return View();
            }

            var user = await _apiService.GetUserInfoAsync(userId, token);
            if (user == null)
            {
                ViewBag.ErrorMessage = "Kullanıcı bilgileri alınamadı.";
                return View();
            }

            ViewData["UserInfo"] = user;
            return View();
        }
    }
}
