namespace ISKI.SARS.WebUI.Areas.InstantValues.ViewModels;

public class InstantValueListRequest
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public ReportTemplateQueryModel Query { get; set; } = new();
}

public class InstantValueItem
{
    public DateTime Timestamp { get; set; }
    public int ReportTemplateTagId { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool Status { get; set; }
}

public class InstantValueListResponse
{
    public List<InstantValueItem> Items { get; set; } = new();
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
}
