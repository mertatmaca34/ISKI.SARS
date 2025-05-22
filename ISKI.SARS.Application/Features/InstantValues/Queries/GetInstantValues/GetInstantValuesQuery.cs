using ISKI.Core.Persistence.Dynamic;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.InstantValues.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.InstantValues.Queries.GetInstantValues;

public class GetInstantValuesQuery : IRequest<PaginatedList<GetInstantValueDto>>
{
    public PageRequest PageRequest { get; set; }
    public DynamicQuery? DynamicQuery { get; set; }
}
