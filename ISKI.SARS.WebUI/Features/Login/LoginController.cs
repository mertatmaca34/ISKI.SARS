using ISKI.SARS.WebUI.Features.Login.Models;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using System.Linq;

namespace ISKI.SARS.WebUI.Features.Login
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
                var loginResponse = await _apiService.LoginAsync(model);
                var token = loginResponse.Token;

                var handler = new JwtSecurityTokenHandler();
                var jwtToken = handler.ReadJwtToken(token);
                var userId = jwtToken.Claims
                    .FirstOrDefault(c => c.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier")
                    ?.Value;

                HttpContext.Session.SetString("AccessToken", token);
                HttpContext.Session.SetString("UserId", userId ?? "");

                var userInfo = await _apiService.GetUserInfoAsync(userId, token);

                HttpContext.Session.SetString("UserFirstName", userInfo.FirstName);

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                ModelState.AddModelError("", "Sunucuya erişilemedi veya hatalı giriş.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
