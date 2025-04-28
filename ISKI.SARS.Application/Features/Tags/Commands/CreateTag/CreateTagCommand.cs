using ISKI.SARS.Application.Features.Tags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Tags.Commands.CreateTag;

public class CreateTagCommand : IRequest<GetTagDto>
{
    public string DisplayName { get; set; }
    public string OpcPath { get; set; }
    public int PullInterval { get; set; }
}
