using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Commands.DeleteArchiveTag;

public class DeleteArchiveTagCommand : IRequest<GetArchiveTagDto>
{
    public int Id { get; set; }
}
