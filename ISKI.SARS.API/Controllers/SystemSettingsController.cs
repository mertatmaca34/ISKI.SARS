using AutoMapper;
using ISKI.SARS.Application.Features.SystemSettings.Dtos;
using ISKI.SARS.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SystemSettingsController : ControllerBase
{
    private readonly ISystemSettingsRepository _repository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;

    public SystemSettingsController(ISystemSettingsRepository repository, IMapper mapper, IConfiguration configuration)
    {
        _repository = repository;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var settings = (await _repository.GetAllAsync()).FirstOrDefault();
        if (settings == null) return NotFound();

        var dto = _mapper.Map<SystemSettingsDto>(settings);
        dto.DatabaseConnection = _configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        return Ok(dto);
    }
}
