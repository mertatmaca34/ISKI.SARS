using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.UpdateReportTemplate;

public class UpdateReportTemplateCommand : IRequest<GetReportTemplateDto>
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}
