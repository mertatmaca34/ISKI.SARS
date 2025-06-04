using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Models;
using ISKI.SARS.WebUI.Services;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using ISKI.Core.Security.JWT;

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
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
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
                var token = System.Text.Json.JsonSerializer.Deserialize<AccessToken>(result);
                if (token != null)
                {
                    HttpContext.Session.SetString("Token", token.Token);
                    var handler = new JwtSecurityTokenHandler();
                    var jwt = handler.ReadJwtToken(token.Token);
                    var role = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                    var name = jwt.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
                    if (!string.IsNullOrEmpty(role))
                        HttpContext.Session.SetString("UserRole", role);
                    if (!string.IsNullOrEmpty(name))
                        HttpContext.Session.SetString("UserName", name);
                }
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
