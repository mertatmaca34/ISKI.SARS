using System;
using System.ComponentModel.DataAnnotations;

namespace ISKI.SARS.WebUI.Models;

public class UserViewModel
{
    public Guid? Id { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    public string LastName { get; set; } = string.Empty;

    [DataType(DataType.Password)]
    public string? Password { get; set; }

    public bool Status { get; set; }
}
