namespace ISKI.SARS.Application.Features.InstantValues.Constants;

public static class InstantValueMessages
{
    // Validation / Business Rule
    public const string TimestampMustBeUnique = "Bu zaman damgasına ait veri zaten mevcut.";
    public const string ValueCannotBeEmpty = "Değer alanı boş olamaz.";
    public const string InvalidTagId = "Geçersiz Tag bilgisi.";

    // Success
    public const string InstantValueCreated = "Anlık değer başarıyla kaydedildi.";
    public const string InstantValueUpdated = "Anlık değer başarıyla güncellendi.";
    public const string InstantValueDeleted = "Anlık değer silindi.";

    // Not Found
    public const string InstantValueNotFound = "İstenen anlık veri bulunamadı.";

    // General Errors
    public const string FailedToSaveInstantValue = "Anlık veri kaydedilirken bir hata oluştu.";
    public const string FailedToUpdateInstantValue = "Anlık veri güncellenirken bir hata oluştu.";
}
