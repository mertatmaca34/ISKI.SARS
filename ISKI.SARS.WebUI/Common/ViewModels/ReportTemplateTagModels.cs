namespace ISKI.SARS.WebUI.Common.ViewModels;

public class ReportTemplateTagListRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public ReportTemplateQueryModel Query { get; set; } = new();
}

public class ReportTemplateTagListResponse
{
    public List<ReportTemplateTagItem> Items { get; set; } = new();
    public int TotalCount { get; set; }
}

public class ReportTemplateTagItem
{
    public string TagName { get; set; } = string.Empty;
    public string TagNodeId { get; set; } = string.Empty;
}
