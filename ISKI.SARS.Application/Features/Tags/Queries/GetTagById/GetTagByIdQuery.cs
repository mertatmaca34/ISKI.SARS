using ISKI.SARS.Application.Features.Tags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Tags.Queries.GetTagById;

public class GetTagByIdQuery : IRequest<GetTagDto>
{
    public Guid Id { get; set; }
}
