using ISKI.SARS.Application.Features.ReportTemplateTags.Dtos;
using MediatR;

public class CreateReportTemplateTagCommand : IRequest<GetReportTemplateTagDto>
{
    public int ReportTemplateId { get; set; }
    public string TagName { get; set; }
    public string TagNodeId { get; set; }
}
