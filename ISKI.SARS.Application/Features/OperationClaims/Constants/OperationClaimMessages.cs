namespace ISKI.SARS.Application.Features.OperationClaims.Constants;

public static class OperationClaimMessages
{
    public const string OperationClaimNameAlreadyExists = "Bu isimde bir yetki zaten mevcut.";
    public const string OperationClaimNotFound = "Yetki bulunamadı.";
    public const string OperationClaimNameCannotBeEmpty = "Yetki adı boş olamaz.";
    public const string OperationClaimNameTooShort = "Yetki adı en az {0} karakter olmalıdır.";
    public const string OperationClaimIdCannotBeEmpty = "Yetki ID'si boş olamaz.";
    public const string OperationClaimIdMustBePositive = "Yetki ID'si pozitif bir değer olmalıdır.";
}
