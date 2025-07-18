using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.DeleteReportTemplate;

public class DeleteReportTemplateCommand : IRequest<GetReportTemplateDto>
{
    public int Id { get; set; }
}
