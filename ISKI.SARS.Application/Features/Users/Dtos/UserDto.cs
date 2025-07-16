﻿namespace ISKI.SARS.Application.Features.Users.Dtos;

public class UserDto
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool Status { get; set; }
    public int? OperationClaimId { get; set; }
    public string? OperationClaimName { get; set; }
}
