using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.ReportTemplateTags.Queries.GetReportTemplateTagById;

public class GetReportTemplateTagByIdQuery(int id) : IRequest<GetReportTemplateTagDto>
{
    public int Id { get; set; } = id;
}