using ISKI.SARS.WebUI.Models;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace ISKI.SARS.WebUI.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(ApiEndpoints.BaseUrl);
        }

        public async Task<LoginResponse> LoginAsync(LoginViewModel model)
        {
            var jsonContent = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(model),
                Encoding.UTF8,
                "application/json"
            );

            var response = await _httpClient.PostAsync(ApiEndpoints.Auth.Login, jsonContent);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<LoginResponse>(responseContent, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
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
    }
}
