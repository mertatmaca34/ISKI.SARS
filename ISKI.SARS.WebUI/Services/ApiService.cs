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

        public async Task<bool> UpdateUserInfoAsync(UserInfoViewModel model, string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Put, "/api/Users");
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            request.Content = JsonContent.Create(model);

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> ChangePasswordAsync(ChangePasswordViewModel model, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var url = $"{ApiEndpoints.BaseUrl}{ApiEndpoints.Users.ChangePassword}";
            var response = await client.PutAsJsonAsync(url, model);
            return response.IsSuccessStatusCode;
        }

        public async Task<(bool IsSuccess, int StatusCode, string? Error)> CreateNewTemplateAsync(NewTemplateViewModel model, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var url = $"{ApiEndpoints.BaseUrl}{ApiEndpoints.Template.CreateTemplate}";
            var response = await client.PostAsJsonAsync(url, model);

            var error = !response.IsSuccessStatusCode ? await response.Content.ReadAsStringAsync() : null;

            return (response.IsSuccessStatusCode, (int)response.StatusCode, error);
        }

        public async Task<ReportTemplateListResponse> GetReportTemplatesAsync(ReportTemplateListRequest request, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var url = $"{ApiEndpoints.BaseUrl}/api/ReportTemplates/list?pageNumber={request.PageNumber}&pageSize={request.PageSize}";
            var response = await client.PostAsJsonAsync(url, request.Query);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<ReportTemplateListResponse>()
                   ?? new ReportTemplateListResponse();
        }

        public async Task<ReportTemplateListResponse> GetReportTemplateListAsync(ReportTemplateListRequest request, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var queryParams = $"?PageNumber={request.PageNumber}&PageSize={request.PageSize}";
            var url = $"{ApiEndpoints.BaseUrl}/api/ReportTemplates/list{queryParams}";

            var response = await client.PostAsJsonAsync(url, request.Query);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ReportTemplateListResponse>() ?? new();
            }

            return new ReportTemplateListResponse();
        }

        public async Task<List<ReportTemplateTagItem>> GetReportTemplateTagListAsync(ReportTemplateTagListRequest request, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(ApiEndpoints.BaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var queryParams = $"?PageNumber={request.PageNumber}&PageSize={request.PageSize}";
            var url = $"{ApiEndpoints.Report.TagList}{queryParams}";

            var json = JsonConvert.SerializeObject(request.Query);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return new List<ReportTemplateTagItem>();

            var responseContent = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ReportTemplateTagListResponse>(responseContent);

            return result?.Items ?? new List<ReportTemplateTagItem>();
        }

        public async Task<InstantValueListResponse> GetInstantValuesAsync(InstantValueListRequest request, string token)
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri(ApiEndpoints.BaseUrl);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var queryParams = $"?PageNumber={request.PageNumber}&PageSize={request.PageSize}";
            var url = $"{ApiEndpoints.InstantValues.List}{queryParams}";

            var json = JsonConvert.SerializeObject(request.Query);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, content);

            if (!response.IsSuccessStatusCode)
                return new InstantValueListResponse();

            return await response.Content.ReadFromJsonAsync<InstantValueListResponse>() ?? new InstantValueListResponse();
        }
    }
}
