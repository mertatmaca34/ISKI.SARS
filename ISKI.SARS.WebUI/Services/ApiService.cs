using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options = new JsonSerializerOptions
    {
        PropertyNameCaseInsensitive = true
    };

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    private async Task<Response<T>> ReadResponse<T>(HttpResponseMessage message)
    {
        var json = await message.Content.ReadAsStringAsync();
        if (message.IsSuccessStatusCode)
        {
            var data = JsonSerializer.Deserialize<T>(json, _options);
            return new Response<T> { IsSuccess = true, Data = data };
        }
        ValidationProblemDetails? details = null;
        try
        {
            details = JsonSerializer.Deserialize<ValidationProblemDetails>(json, _options);
        }
        catch { }
        return new Response<T> { IsSuccess = false, Errors = details?.Errors };
    }

    public async Task<Response<T>> GetAsync<T>(string url, string? token = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        var response = await _httpClient.SendAsync(request);
        return await ReadResponse<T>(response);
    }

    public async Task<Response<T>> PostAsync<T>(string url, object? body, string? token = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Post, url)
        {
            Content = body == null ? null : new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
        };
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        var response = await _httpClient.SendAsync(request);
        return await ReadResponse<T>(response);
    }

    public async Task<Response<T>> PutAsync<T>(string url, object? body, string? token = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Put, url)
        {
            Content = body == null ? null : new StringContent(JsonSerializer.Serialize(body), Encoding.UTF8, "application/json")
        };
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        var response = await _httpClient.SendAsync(request);
        return await ReadResponse<T>(response);
    }

    public async Task<Response<T>> DeleteAsync<T>(string url, string? token = null)
    {
        var request = new HttpRequestMessage(HttpMethod.Delete, url);
        if (!string.IsNullOrEmpty(token))
        {
            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        var response = await _httpClient.SendAsync(request);
        return await ReadResponse<T>(response);
    }
}
