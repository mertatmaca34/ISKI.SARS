using ISKI.Core.Security.Dtos;
using ISKI.SARS.Application.Features.Auths.Commands.Register;
using ISKI.SARS.Application.Features.Auths.Commands.Login;
using ISKI.SARS.Application.Features.Auths.Commands.RefreshToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ISKI.SARS.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        RegisterCommand command = new() { RegisterDto = registerDto, IpAddress = GetIpAddress() };
        var result = await _mediator.Send(command);
        return Created("", result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        LoginCommand command = new() { LoginDto = loginDto, IpAddress = GetIpAddress() };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    [HttpPost("refresh-token")]
    public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto dto)
    {
        RefreshTokenCommand command = new() { RefreshToken = dto.RefreshToken, IpAddress = GetIpAddress() };
        var result = await _mediator.Send(command);
        return Ok(result);
    }

    private string GetIpAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        return HttpContext.Connection.RemoteIpAddress?.ToString() ?? "localhost";
    }
}
