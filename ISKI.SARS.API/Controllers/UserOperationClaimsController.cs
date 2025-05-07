using ISKI.SARS.Application.Features.UserOperationClaims.Commands.Create;
using ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetById;
using ISKI.SARS.Application.Features.UserOperationClaims.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserOperationClaimsController(IMediator mediator) : ControllerBase
{

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetUserOperationClaimListQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await mediator.Send(new GetUserOperationClaimByIdQuery { Id = id });
        return Ok(result);
    }
}