namespace ISKI.SARS.Application.Features.Tags.Dtos;

public class GetTagDto
{
    public Guid Id { get; set; }
    public string DisplayName { get; set; } = string.Empty;
    public string OpcPath { get; set; } = string.Empty;
    public int PullInterval { get; set; }
    public DateTime CreatedAt { get; set; }
}
