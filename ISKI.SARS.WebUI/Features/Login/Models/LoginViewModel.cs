using System.ComponentModel.DataAnnotations;

namespace ISKI.SARS.WebUI.Features.Login.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şifre zorunludur.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}


namespace ISKI.SARS.WebUI.Features.Login.Models
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public string Expiration { get; set; }
    }
}


