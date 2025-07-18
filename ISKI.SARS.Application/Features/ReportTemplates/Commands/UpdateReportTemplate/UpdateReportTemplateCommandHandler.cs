using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.UpdateReportTemplate;

public class UpdateReportTemplateCommandHandler(
    IReportTemplateRepository repository,
    IMapper mapper,
    ReportTemplateBusinessRules rules)
    : IRequestHandler<UpdateReportTemplateCommand, GetReportTemplateDto>
{
    public async Task<GetReportTemplateDto> Handle(UpdateReportTemplateCommand request, CancellationToken cancellationToken)
    {
        await rules.ReportTemplateMustExist(request.Id);

        var entity = await repository.GetByIdAsync(request.Id);
        mapper.Map(request, entity!);

        var updated = await repository.UpdateAsync(entity!);
        return mapper.Map<GetReportTemplateDto>(updated);
    }
}
