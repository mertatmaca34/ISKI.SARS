namespace ISKI.SARS.WebUI.ViewModels.Users;

public class UserVm
{
    public Guid Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool Status { get; set; }
    public string Password { get; set; } = string.Empty; // for create/update
}
