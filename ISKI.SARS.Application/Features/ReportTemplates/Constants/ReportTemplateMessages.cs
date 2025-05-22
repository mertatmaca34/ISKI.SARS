namespace ISKI.SARS.Application.Features.ReportTemplates.Constants;

public static class ReportTemplateMessages
{
    public const string NameAlreadyExists = "Bu isimde bir şablon zaten mevcut.";
    public const string NotFound = "Rapor şablonu bulunamadı."; 
    public const string NameIsRequired = "Şablon adı boş olamaz.";
    public const string OpcEndpointIsRequired = "OPC endpoint boş olamaz.";
    public const string PullIntervalTooLow = "Çekim aralığı en az 1000 ms olmalıdır.";

}
