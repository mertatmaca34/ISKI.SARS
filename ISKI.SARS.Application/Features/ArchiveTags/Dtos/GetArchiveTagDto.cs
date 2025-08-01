namespace ISKI.SARS.Application.Features.ArchiveTags.Dtos;

public class GetArchiveTagDto
{
    public int Id { get; set; }
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public string? Description { get; set; }
    public ISKI.SARS.Domain.Enums.TagTypes Type { get; set; }
    public bool IsActive { get; set; }
}
