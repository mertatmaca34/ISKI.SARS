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
        var entity = await repository.GetByIdForUserAsync(request.Id, request.UserId);

        if (entity is null)
            throw new BusinessException(ReportTemplateMessages.NotFound);

        var dto = mapper.Map<GetReportTemplateDto>(entity);
        dto.IsShared = entity.CreatedByUserId != request.UserId;
        return dto;
    }
}