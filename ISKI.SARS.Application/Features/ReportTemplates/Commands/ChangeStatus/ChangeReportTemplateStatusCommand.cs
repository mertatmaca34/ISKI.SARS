using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplates.Commands.ChangeStatus;

public class ChangeReportTemplateStatusCommand : IRequest<GetReportTemplateDto>
{
    public int Id { get; set; }
    public bool IsActive { get; set; }
}
