using AutoMapper;
using ISKI.SARS.WebUI.DTOs.Tags;
using ISKI.SARS.WebUI.Services;
using ISKI.SARS.WebUI.ViewModels.Tags;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ISKI.SARS.WebUI.Pages.Tags;

public class IndexModel : PageModel
{
    private readonly ApiService _apiService;
    private readonly TokenService _tokenService;
    private readonly IMapper _mapper;

    public List<TagVm> Tags { get; set; } = new();

    public IndexModel(ApiService apiService, TokenService tokenService, IMapper mapper)
    {
        _apiService = apiService;
        _tokenService = tokenService;
        _mapper = mapper;
    }

    public async Task OnGetAsync()
    {
        var token = _tokenService.GetToken();
        var response = await _apiService.GetAsync<List<TagDto>>("/api/tags", token);
        if (response.IsSuccess && response.Data != null)
        {
            Tags = _mapper.Map<List<TagVm>>(response.Data);
        }
    }
}
