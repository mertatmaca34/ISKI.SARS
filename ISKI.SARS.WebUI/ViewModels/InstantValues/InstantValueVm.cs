namespace ISKI.SARS.WebUI.ViewModels.InstantValues;

public class InstantValueVm
{
    public DateTime Timestamp { get; set; }
    public int ReportTemplateTagId { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool Status { get; set; }
}
