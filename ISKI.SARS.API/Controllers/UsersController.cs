using ISKI.SARS.Application.Features.Users.Commands.Create;
using ISKI.SARS.Application.Features.Users.Commands.Update;
using ISKI.SARS.Application.Features.Users.Commands.Delete;
using ISKI.SARS.Application.Features.Users.Queries.GetById;
using ISKI.SARS.Application.Features.Users.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ISKI.SARS.Application.Features.Users.Commands.ChangePassword;
using ISKI.Core.Security.Constants;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController(IMediator mediator) : ControllerBase
{
    [Authorize(Roles = GeneralOperationClaims.Admin)]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin + "," + GeneralOperationClaims.Operator)]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin)]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await mediator.Send(new DeleteUserCommand { Id = id });
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin + "," + GeneralOperationClaims.Operator)]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var result = await mediator.Send(new GetUserByIdQuery { Id = id });
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin)]
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] GetUserListQuery query)
    {
        var result = await mediator.Send(query);
        return Ok(result);
    }

    [Authorize(Roles = GeneralOperationClaims.Admin + "," + GeneralOperationClaims.Operator)]
    [HttpPut("change-password")]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordCommand command)
    {
        var result = await mediator.Send(command);
        return Ok(result);
    }
}
