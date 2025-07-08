using ISKI.SARS.WebUI.Features.NewTemplate.Models;
using ISKI.SARS.WebUI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ISKI.SARS.WebUI.Features.NewTemplate
{
    public class NewTemplateController : Controller
    {
        private readonly IApiService _apiService;

        public NewTemplateController(IApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new NewTemplateViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Index([FromBody] NewTemplateViewModel model)
        {
            var token = HttpContext.Session.GetString("AccessToken");

            if (string.IsNullOrEmpty(token))
                return Json(new { success = false, status = 401, message = "Oturum süresi doldu. Lütfen tekrar giriş yapın." });

            if (!ModelState.IsValid)
                return Json(new { success = false, status = 400, message = "Tüm alanları doldurduğunuzdan emin olun." });

            var result = await _apiService.CreateNewTemplateAsync(model, token);

            if (result.IsSuccess)
            {
                return Json(new { success = true, message = "Şablon başarıyla oluşturuldu." });
            }

            return Json(new { success = false, status = result.StatusCode, message = $"Şablon oluşturulamadı. (Hata Kodu: {result.StatusCode})" });
        }
    }
}
