using ISKI.SARS.Application.Features.OperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Update;
using ISKI.SARS.Application.Features.OperationClaims.Commands.Delete;
using ISKI.SARS.Application.Features.OperationClaims.Queries.GetById;
using ISKI.SARS.Application.Features.OperationClaims.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ISKI.Core.Security.Constants;

namespace ISKI.SARS.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = GeneralOperationClaims.Admin)]
public class OperationClaimsController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await mediator.Send(new DeleteOperationClaimCommand { Id = id });
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetOperationClaimByIdQuery { Id = id });
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetOperationClaimListQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }
}
