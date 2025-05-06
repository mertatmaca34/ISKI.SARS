using global::ISKI.SARS.WebUI.Models;
using Newtonsoft.Json;
using System.Text;

namespace ISKI.SARS.WebUI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new System.Uri(ApiEndpoints.BaseUrl);
        }

        public async Task<string> LoginAsync(LoginViewModel model)
        {
            var jsonContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(ApiEndpoints.Auth.Login, jsonContent);

            response.EnsureSuccessStatusCode(); // Eğer başarısızsa exception fırlatır

            var result = await response.Content.ReadAsStringAsync();
            return result; // JWT veya login sonucu
        }
    }
}
