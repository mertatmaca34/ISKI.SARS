using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Constants;
using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using ISKI.SARS.Domain.Services;
using MediatR;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Queries.GetReportTemplateArchiveTagById;

public class GetReportTemplateArchiveTagByIdQueryHandler(
    IReportTemplateArchiveTagRepository repository,
    IMapper mapper)
    : IRequestHandler<GetReportTemplateArchiveTagByIdQuery, GetReportTemplateArchiveTagDto>
{
    public async Task<GetReportTemplateArchiveTagDto> Handle(GetReportTemplateArchiveTagByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);
        if (entity is null)
            throw new BusinessException(ReportTemplateArchiveTagMessages.NotFound);

        return mapper.Map<GetReportTemplateArchiveTagDto>(entity);
    }
}
