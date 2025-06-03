using ISKI.SARS.WebUI.Models;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;

public class UserInfoController : Controller
{
    private readonly IApiService _apiService;

    public UserInfoController(IApiService apiService)
    {
        _apiService = apiService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var userId = HttpContext.Session.GetString("UserId");
        var token = HttpContext.Session.GetString("AccessToken");

        if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(token))
        {
            TempData["ErrorMessage"] = "Oturum geçerli değil. Lütfen tekrar giriş yapınız.";
            return RedirectToAction("Index", "Login");
        }

        var userInfo = await _apiService.GetUserInfoAsync(userId, token);
        if (userInfo == null)
        {
            TempData["ErrorMessage"] = "Kullanıcı bilgileri alınamadı.";
            return RedirectToAction("Index", "Home");
        }

        return View(userInfo);
    }

    [HttpPost]
    public async Task<IActionResult> Update(UserInfoViewModel model)
    {
        var token = HttpContext.Session.GetString("AccessToken");
        if (string.IsNullOrEmpty(token))
        {
            TempData["ErrorMessage"] = "Geçersiz oturum.";
            return RedirectToAction("Index");
        }

        var success = await _apiService.UpdateUserInfoAsync(model, token);
        if (success)
        {
            TempData["SuccessMessage"] = "Kullanıcı bilgileri başarıyla güncellendi.";
        }
        else
        {
            TempData["ErrorMessage"] = "Kullanıcı bilgileri güncellenemedi.";
        }

        return RedirectToAction("Index");
    }
}
