using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Update;
using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Delete;
using ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetById;
using ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserOperationClaimsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _mediator.Send(new DeleteUserOperationClaimCommand { Id = id });
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetUserOperationClaimListQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _mediator.Send(new GetUserOperationClaimByIdQuery { Id = id });
        return Ok(result);
    }
}
