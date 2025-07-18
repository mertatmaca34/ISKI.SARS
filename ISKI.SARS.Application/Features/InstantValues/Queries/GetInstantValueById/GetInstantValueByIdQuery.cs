using ISKI.SARS.Application.Features.InstantValues.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.InstantValues.Queries.GetInstantValueById;

public class GetInstantValueByIdQuery(DateTime timestamp) : IRequest<GetInstantValueDto>
{
    public DateTime Timestamp { get; set; } = timestamp;
}
