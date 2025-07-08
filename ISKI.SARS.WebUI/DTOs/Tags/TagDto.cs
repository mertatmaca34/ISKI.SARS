namespace ISKI.SARS.WebUI.DTOs.Tags;

public class TagDto
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string OpcPath { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
