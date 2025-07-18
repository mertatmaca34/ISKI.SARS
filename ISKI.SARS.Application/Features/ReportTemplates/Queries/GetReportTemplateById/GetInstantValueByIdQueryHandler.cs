using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Constants;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Domain.Services;
using MediatR;
using ISKI.Core.CrossCuttingConcerns.Exceptions;

namespace ISKI.SARS.Application.Features.ReportTemplates.Queries.GetReportTemplateById;

public class GetReportTemplateByIdQueryHandler(
    IReportTemplateRepository repository,
    IMapper mapper,
    ReportTemplateBusinessRules rules)
    : IRequestHandler<GetReportTemplateByIdQuery, GetReportTemplateDto>
{
    public async Task<GetReportTemplateDto> Handle(GetReportTemplateByIdQuery request, CancellationToken cancellationToken)
    {
        var entity = await repository.GetByIdAsync(request.Id);

        if (entity is null)
            throw new BusinessException(ReportTemplateMessages.NotFound);

        return mapper.Map<GetReportTemplateDto>(entity);
    }
}