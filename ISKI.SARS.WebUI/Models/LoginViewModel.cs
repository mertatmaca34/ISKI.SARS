using System.ComponentModel.DataAnnotations;
namespace ISKI.SARS.WebUI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "E-Posta giriniz")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre giriniz")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
