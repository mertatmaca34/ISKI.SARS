namespace ISKI.SARS.Application.Features.Users.Constants;

public static class UserMessages
{
    public const string UserNotFound = "Kullanıcı bulunamadı.";
    public const string EmailAlreadyExists = "Bu e-posta adresi zaten kullanılmakta.";
    public const string InvalidEmail = "Geçerli bir e-posta adresi girin.";
    public const string PasswordTooShort = "Şifre en az 6 karakter olmalıdır.";
    public const string InvalidUserId = "Kullanıcı ID boş olamaz.";
    public const string UpdateNotAllowed = "Sadece kendi bilgilerinizi güncelleyebilirsiniz.";
    public const string PasswordMismatch = "Şifreler eşleşmiyor.";
    public const string UserAlreadyExists = "Bu kullanıcı zaten mevcut.";
    public const string UserCreationFailed = "Kullanıcı oluşturulamadı.";
    public const string UserUpdateFailed = "Kullanıcı güncellenemedi.";
    public const string UserDeletionFailed = "Kullanıcı silinemedi.";
    public const string UserIdCannotBeEmpty = "Kullanıcı ID boş olamaz.";
    public const string OldPasswordCannotBeEmpty = "Eski şifre boş olamaz.";
    public const string OldPasswordMinLength = "Eski şifre en az 6 karakter olmalıdır.";
    public const string NewPasswordCannotBeEmpty = "Yeni şifre boş olamaz.";
    public const string NewPasswordMinLength = "Yeni şifre en az 6 karakter olmalıdır.";
    public const string NewPasswordCannotBeSame = "Yeni şifre eski şifreyle aynı olamaz.";
    public const string OldPasswordWrong = "Mevcut şifre hatalı.";
}
