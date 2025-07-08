using System.ComponentModel.DataAnnotations;

namespace ISKI.SARS.WebUI.Features.Register.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Ad gereklidir.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Soyad gereklidir.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email gereklidir.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Şifre gereklidir.")]
        [MinLength(6, ErrorMessage = "Şifre en az 6 karakter olmalıdır.")]
        public string Password { get; set; } = string.Empty;

        [Compare("Password", ErrorMessage = "Şifreler eşleşmiyor.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
