using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Application.Features.ReportTemplates.Rules;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Domain.Services;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.DeleteReportTemplate;

public class DeleteReportTemplateCommandHandler(
    IReportTemplateRepository repository,
    IMapper mapper,
    ReportTemplateBusinessRules rules)
    : IRequestHandler<DeleteReportTemplateCommand, GetReportTemplateDto>
{
    public async Task<GetReportTemplateDto> Handle(DeleteReportTemplateCommand request, CancellationToken cancellationToken)
    {
        await rules.ReportTemplateMustExist(request.Id);
        var entity = await repository.GetByIdAsync(request.Id);
        var deleted = await repository.DeleteAsync(entity!);
        return mapper.Map<GetReportTemplateDto>(deleted!);
    }
}
