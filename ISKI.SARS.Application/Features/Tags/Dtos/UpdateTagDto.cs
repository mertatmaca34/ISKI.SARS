namespace ISKI.SARS.Application.Features.Tags.Dtos;

public class UpdateTagDto
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string OpcPath { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
