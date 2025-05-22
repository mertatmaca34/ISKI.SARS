using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands;

public class CreateReportTemplateCommandHandler(
    IReportTemplateRepository repository,
    IMapper mapper,
    ReportTemplateBusinessRules rules)
    : IRequestHandler<CreateReportTemplateCommand, GetReportTemplateDto>
{
    public async Task<GetReportTemplateDto> Handle(CreateReportTemplateCommand request, CancellationToken cancellationToken)
    {
        await rules.NameMustBeUnique(request.Name);

        var entity = mapper.Map<ReportTemplate>(request);
        entity.CreatedAt = DateTime.UtcNow;

        var created = await repository.AddAsync(entity);
        return mapper.Map<GetReportTemplateDto>(created);
    }
}