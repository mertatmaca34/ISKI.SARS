using System.ComponentModel.DataAnnotations;

namespace ISKI.SARS.WebUI.Models;

public class TagViewModel
{
    public int? Id { get; set; }

    [Required]
    public int ReportTemplateId { get; set; }

    [Required]
    public string TagName { get; set; } = string.Empty;

    [Required]
    public string TagNodeId { get; set; } = string.Empty;
}
