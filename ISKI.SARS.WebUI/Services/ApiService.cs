using ISKI.SARS.WebUI.Models;
using System.Net.Http.Json;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Http;
using System.Net.Http.Headers;

namespace ISKI.SARS.WebUI.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _contextAccessor;

    public ApiService(HttpClient httpClient, IHttpContextAccessor contextAccessor)
    {
        _httpClient = httpClient;
        _contextAccessor = contextAccessor;
        _httpClient.BaseAddress = new Uri(ApiEndpoints.BaseUrl);
    }

    private void AddAuthHeader()
    {
        var token = _contextAccessor.HttpContext?.Session.GetString("Token");
        if (!string.IsNullOrEmpty(token))
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }

    public async Task<string> LoginAsync(LoginViewModel model)
    {
        var jsonContent = new StringContent(System.Text.Json.JsonSerializer.Serialize(model), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync(ApiEndpoints.Auth.Login, jsonContent);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsStringAsync();
    }

    public async Task<bool> RegisterAsync(RegisterViewModel model)
    {
        var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.Auth.Register, model);
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<UserViewModel>> GetUsersAsync()
    {
        AddAuthHeader();
        return await _httpClient.GetFromJsonAsync<IEnumerable<UserViewModel>>(ApiEndpoints.Users.Base) ?? [];
    }

    public async Task<UserViewModel?> GetUserByIdAsync(Guid id)
    {
        AddAuthHeader();
        return await _httpClient.GetFromJsonAsync<UserViewModel>($"{ApiEndpoints.Users.Base}/{id}");
    }

    public async Task<bool> CreateUserAsync(UserViewModel model)
    {
        AddAuthHeader();
        var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.Users.Base, model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateUserAsync(UserViewModel model)
    {
        AddAuthHeader();
        var response = await _httpClient.PutAsJsonAsync(ApiEndpoints.Users.Base, model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteUserAsync(Guid id)
    {
        AddAuthHeader();
        var response = await _httpClient.DeleteAsync($"{ApiEndpoints.Users.Base}/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<TagViewModel>> GetTagsAsync(int templateId)
    {
        AddAuthHeader();
        var dynamicUrl = $"{ApiEndpoints.ReportTemplateTags.Base}/list?pageNumber=1&pageSize=100&templateId={templateId}";
        return await _httpClient.GetFromJsonAsync<IEnumerable<TagViewModel>>(dynamicUrl) ?? [];
    }

    public async Task<TagViewModel?> GetTagByIdAsync(int id)
    {
        AddAuthHeader();
        return await _httpClient.GetFromJsonAsync<TagViewModel>($"{ApiEndpoints.ReportTemplateTags.Base}/{id}");
    }

    public async Task<bool> CreateTagAsync(TagViewModel model)
    {
        AddAuthHeader();
        var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.ReportTemplateTags.Base, model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> UpdateTagAsync(TagViewModel model)
    {
        AddAuthHeader();
        var response = await _httpClient.PutAsJsonAsync(ApiEndpoints.ReportTemplateTags.Base, model);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> DeleteTagAsync(int id)
    {
        AddAuthHeader();
        var response = await _httpClient.DeleteAsync($"{ApiEndpoints.ReportTemplateTags.Base}/{id}");
        return response.IsSuccessStatusCode;
    }

    public async Task<IEnumerable<ReportTemplateViewModel>> GetReportTemplatesAsync()
    {
        AddAuthHeader();
        var dynamicUrl = $"{ApiEndpoints.ReportTemplates.Base}/list?pageNumber=1&pageSize=100";
        return await _httpClient.GetFromJsonAsync<IEnumerable<ReportTemplateViewModel>>(dynamicUrl) ?? [];
    }

    public async Task<ReportTemplateViewModel?> GetReportTemplateByIdAsync(int id)
    {
        AddAuthHeader();
        return await _httpClient.GetFromJsonAsync<ReportTemplateViewModel>($"{ApiEndpoints.ReportTemplates.Base}/{id}");
    }

    public async Task<bool> CreateReportTemplateAsync(ReportTemplateViewModel model)
    {
        AddAuthHeader();
        var response = await _httpClient.PostAsJsonAsync(ApiEndpoints.ReportTemplates.Base, model);
        return response.IsSuccessStatusCode;
    }

    public async Task<byte[]> GetReportPdfAsync(int templateId)
    {
        AddAuthHeader();
        return await _httpClient.GetByteArrayAsync($"{ApiEndpoints.ReportTemplates.Base}/{templateId}/pdf");
    }

    public async Task<byte[]> GetReportExcelAsync(int templateId)
    {
        AddAuthHeader();
        return await _httpClient.GetByteArrayAsync($"{ApiEndpoints.ReportTemplates.Base}/{templateId}/excel");
    }
}

