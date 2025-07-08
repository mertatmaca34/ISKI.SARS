namespace ISKI.SARS.WebUI.ViewModels.Users;

public class ChangePasswordVm
{
    public Guid UserId { get; set; }
    public string OldPassword { get; set; } = string.Empty;
    public string NewPassword { get; set; } = string.Empty;
}
