using ISKI.SARS.Application.Features.ArchiveTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ArchiveTags.Queries.GetArchiveTagById;

public class GetArchiveTagByIdQuery(int id) : IRequest<GetArchiveTagDto>
{
    public int Id { get; set; } = id;
}
