using ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateArchiveTags.Queries.GetReportTemplateArchiveTagById;

public class GetReportTemplateArchiveTagByIdQuery(int id) : IRequest<GetReportTemplateArchiveTagDto>
{
    public int Id { get; set; } = id;
}
