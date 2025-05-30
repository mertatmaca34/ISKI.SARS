using ISKI.SARS.WebUI.Models;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;

namespace ISKI.SARS.WebUI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, IHttpClientFactory httpClientFactory, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(ApiEndpoints.BaseUrl);
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<LoginResponse> LoginAsync(LoginViewModel model)
        {
            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(model),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(ApiEndpoints.Auth.Login, jsonContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<LoginResponse>(responseContent);
        }

        public async Task<bool> RegisterAsync(RegisterViewModel model)
        {
            var payload = new
            {
                firstName = model.FirstName,
                lastName = model.LastName,
                email = model.Email,
                password = model.Password
            };

            var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.Auth.Register, payload);
            return response.IsSuccessStatusCode;
        }

        public async Task<UserInfoViewModel?> GetUserInfoAsync(string userId, string token)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                client.BaseAddress = new Uri(ApiEndpoints.BaseUrl);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                var url = string.Format(ApiEndpoints.Users.GetById, userId);
                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Kullanıcı bilgisi alınamadı. StatusCode: {StatusCode}, URL: {Url}", response.StatusCode, url);
                    return null;
                }

                var jsonString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(jsonString))
                {
                    _logger.LogWarning("API boş yanıt döndü: {Url}", url);
                    return null;
                }

                var userInfo = JsonConvert.DeserializeObject<UserInfoViewModel>(jsonString);

                if (userInfo == null)
                {
                    _logger.LogError("Kullanıcı JSON deserialize edilemedi: {Json}", jsonString);
                    return null;
                }

                return userInfo;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "GetUserInfoAsync sırasında beklenmedik bir hata oluştu.");
                return null;
            }
        }
    }
}
