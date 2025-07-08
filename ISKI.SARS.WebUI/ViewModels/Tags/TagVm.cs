namespace ISKI.SARS.WebUI.ViewModels.Tags;

public class TagVm
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string OpcPath { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
