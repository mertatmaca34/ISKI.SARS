using System.Text.Json.Serialization;

namespace ISKI.SARS.WebUI.Features.NewTemplate.Models
{
    public class NewTemplateViewModel
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;

        [JsonPropertyName("opcEndpoint")]
        public string OpcEndpoint { get; set; } = string.Empty;

        [JsonPropertyName("pullInterval")]
        public int PullInterval { get; set; }
    }
}
