﻿using ISKI.SARS.Application.Features.Users.Commands.Create;

namespace ISKI.SARS.Application.Features.Users.Commands.Create;

public class CreatedUserResponse
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
