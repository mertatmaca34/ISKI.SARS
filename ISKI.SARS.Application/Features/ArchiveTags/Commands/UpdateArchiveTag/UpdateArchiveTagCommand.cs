using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using ISKI.SARS.Domain.Enums;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.UpdateArchiveTag;

public class UpdateArchiveTagCommand : IRequest<GetArchiveTagDto>
{
    public int Id { get; set; }
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
    public string? Description { get; set; }
    public TagTypes Type { get; set; }
    public bool IsActive { get; set; }
}
