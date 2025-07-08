using AutoMapper;
using Newtonsoft.Json;
using Serilog;
using System.Net.Http.Headers;

namespace ISKI.SARS.WebUI.Services;

public class ApiService(HttpClient httpClient, TokenService tokenService, IMapper mapper)
{
    private readonly HttpClient _httpClient = httpClient;
    private readonly TokenService _tokenService = tokenService;
    private readonly IMapper _mapper = mapper;

    private void AddJwtHeader()
    {
        var token = _tokenService.GetToken();
        if (!string.IsNullOrWhiteSpace(token))
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public async Task<T?> GetAsync<T>(string url)
    {
        AddJwtHeader();
        var response = await _httpClient.GetAsync(url);
        if (!response.IsSuccessStatusCode)
            return default;

        var content = await response.Content.ReadAsStringAsync();
        try
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Deserialization error");
            return default;
        }
    }

    public async Task<T?> PostAsync<T>(string url, object data)
    {
        AddJwtHeader();
        var json = JsonConvert.SerializeObject(data);
        var response = await _httpClient.PostAsync(url, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
            return default;

        var content = await response.Content.ReadAsStringAsync();
        try
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Deserialization error");
            return default;
        }
    }

    public async Task<T?> PutAsync<T>(string url, object data)
    {
        AddJwtHeader();
        var json = JsonConvert.SerializeObject(data);
        var response = await _httpClient.PutAsync(url, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
        if (!response.IsSuccessStatusCode)
            return default;

        var content = await response.Content.ReadAsStringAsync();
        try
        {
            return JsonConvert.DeserializeObject<T>(content);
        }
        catch (Exception ex)
        {
            Log.Error(ex, "Deserialization error");
            return default;
        }
    }

    public async Task DeleteAsync(string url)
    {
        AddJwtHeader();
        await _httpClient.DeleteAsync(url);
    }
}
