using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.ChangeStatus;

public class ChangeReportTemplateStatusCommandHandler(
    IReportTemplateRepository repository,
    IMapper mapper,
    ReportTemplateBusinessRules rules) : IRequestHandler<ChangeReportTemplateStatusCommand, GetReportTemplateDto>
{
    public async Task<GetReportTemplateDto> Handle(ChangeReportTemplateStatusCommand request, CancellationToken cancellationToken)
    {
        await rules.ReportTemplateMustExist(request.Id);
        var entity = await repository.GetByIdAsync(request.Id);
        entity!.IsActive = request.IsActive;

        var updated = await repository.UpdateAsync(entity);
        return mapper.Map<GetReportTemplateDto>(updated);
    }
}
