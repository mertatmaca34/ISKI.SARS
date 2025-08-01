using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.DeleteReportTemplateArchiveTag;

public class DeleteReportTemplateArchiveTagCommand : IRequest<GetReportTemplateArchiveTagDto>
{
    public int Id { get; set; }
}
