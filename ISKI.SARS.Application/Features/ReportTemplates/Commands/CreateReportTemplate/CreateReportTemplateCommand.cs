using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.Domain.Enums;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.CreateReportTemplate;

public class CreateReportTemplateCommand : IRequest<GetReportTemplateDto>
{
    public string Name { get; set; }
    public string OpcEndpoint { get; set; }
    public int PullInterval { get; set; }
    public bool IsActive { get; set; }
}