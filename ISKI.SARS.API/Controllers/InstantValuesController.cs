using ISKI.SARS.Application.Features.InstantValues.Commands.CreateInstantValue;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using ISKI.SARS.Application.Features.InstantValues.Queries.GetInstantValueById;
using ISKI.SARS.Application.Features.InstantValues.Queries.GetInstantValues;
using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstantValuesController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateInstantValueCommand command)
    {
        GetInstantValueDto result = await mediator.Send(command);
        return CreatedAtAction(nameof(GetByTimestamp), new { timestamp = result.Timestamp }, result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpGet("{timestamp}")]
    public async Task<IActionResult> GetByTimestamp(DateTime timestamp)
    {
        var query = new GetInstantValueByIdQuery(timestamp);
        GetInstantValueDto result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = "Admin,Operator")]
    [HttpPost("list")]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] DynamicQuery? dynamicQuery)
    {
        var query = new GetInstantValuesQuery
        {
            PageRequest = pageRequest,
            DynamicQuery = dynamicQuery
        };

        PaginatedList<GetInstantValueDto> result = await mediator.Send(query);
        return Ok(result);
    }
}
