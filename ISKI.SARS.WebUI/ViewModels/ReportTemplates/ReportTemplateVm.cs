namespace ISKI.SARS.WebUI.ViewModels.ReportTemplates;

public class ReportTemplateVm
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string OpcEndpoint { get; set; } = string.Empty;
    public int PullInterval { get; set; }
}
