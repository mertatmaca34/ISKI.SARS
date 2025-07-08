using AutoMapper;
using ISKI.Core.CrossCuttingConcerns.Exceptions.ExceptionHandling;
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

    private async Task<ApiResult<T>> ParseResponse<T>(HttpResponseMessage response)
    {
        var content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            try
            {
                var data = JsonConvert.DeserializeObject<T>(content);
                return new ApiResult<T>(data);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Deserialization error");
                var error = new ErrorResponse((int)response.StatusCode, "Invalid response");
                return new ApiResult<T>(error);
            }
        }

        ErrorResponse? parsedError = null;
        try
        {
            parsedError = JsonConvert.DeserializeObject<ErrorResponse>(content);
        }
        catch { }
        parsedError ??= new ErrorResponse((int)response.StatusCode, response.ReasonPhrase ?? "Error");
        return new ApiResult<T>(parsedError);
    }

    public async Task<ApiResult<T>> GetAsync<T>(string url)
    {
        AddJwtHeader();
        var response = await _httpClient.GetAsync(url);
        return await ParseResponse<T>(response);
    }

    public async Task<ApiResult<T>> PostAsync<T>(string url, object data)
    {
        AddJwtHeader();
        var json = JsonConvert.SerializeObject(data);
        var response = await _httpClient.PostAsync(url, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
        return await ParseResponse<T>(response);
    }

    public async Task<ApiResult<T>> PutAsync<T>(string url, object data)
    {
        AddJwtHeader();
        var json = JsonConvert.SerializeObject(data);
        var response = await _httpClient.PutAsync(url, new StringContent(json, System.Text.Encoding.UTF8, "application/json"));
        return await ParseResponse<T>(response);
    }

    public async Task DeleteAsync(string url)
    {
        AddJwtHeader();
        await _httpClient.DeleteAsync(url);
    }
}
