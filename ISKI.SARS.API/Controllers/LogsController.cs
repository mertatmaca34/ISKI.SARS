using ISKI.SARS.Application.Features.Logs.Commands.CreateLog;
using ISKI.SARS.Application.Features.Logs.Commands.UpdateLog;
using ISKI.SARS.Application.Features.Logs.Commands.DeleteLog;
using ISKI.SARS.Application.Features.Logs.Queries.GetLogById;
using ISKI.SARS.Application.Features.Logs.Queries.GetLogs;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class LogsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLogCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLogCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteLogCommand { Id = id });
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetLogByIdQuery(id));
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetLogListQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
