namespace ISKI.SARS.Application.Features.Users.Constants;

public static class UserMessages
{
    public const string UserNotFound = "Kullanıcı bulunamadı.";
    public const string EmailAlreadyExists = "Bu e-posta adresi zaten kullanılmakta.";
    public const string InvalidEmail = "Geçerli bir e-posta adresi girin.";
    public const string PasswordTooShort = "Şifre en az 6 karakter olmalıdır.";
    public const string InvalidUserId = "Kullanıcı ID boş olamaz.";
    public const string UpdateNotAllowed = "Sadece kendi bilgilerinizi güncelleyebilirsiniz.";
}
