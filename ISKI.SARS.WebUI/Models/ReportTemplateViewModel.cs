using ISKI.SARS.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace ISKI.SARS.WebUI.Models;

public class ReportTemplateViewModel
{
    public int? Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string OpcEndpoint { get; set; } = string.Empty;

    [Range(1000, int.MaxValue)]
    public int PullInterval { get; set; }

    [Required]
    public TagTypes Type { get; set; }
}
