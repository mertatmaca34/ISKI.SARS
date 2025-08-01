using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Commands.CreateReportTemplateArchiveTag;

public class CreateReportTemplateArchiveTagCommand : IRequest<GetReportTemplateArchiveTagDto>
{
    public int ReportTemplateId { get; set; }
    public int ArchiveTagId { get; set; }
}
