using ISKI.SARS.Application.Features.SystemSettings.Dtos;
using ISKI.SARS.Application.Features.SystemSettings.Queries.GetSystemSettings;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SystemSettingsController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin,Operator")]
    [HttpGet]
    public async Task<ActionResult<SystemSettingDto>> Get()
    {
        var query = new GetSystemSettingsQuery();
        SystemSettingDto result = await mediator.Send(query);
        return Ok(result);
    }
}
