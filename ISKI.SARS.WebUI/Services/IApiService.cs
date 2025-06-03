using System.Threading.Tasks;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Services
{
    public interface IApiService
    {
        Task<LoginResponse> LoginAsync(LoginViewModel model);
        Task<bool> RegisterAsync(RegisterViewModel model);
        Task<UserInfoViewModel?> GetUserInfoAsync(string userId, string token);
        Task<bool> UpdateUserAsync(UserInfoViewModel model, string token);
        Task<bool> UpdateUserInfoAsync(UserInfoViewModel model, string token);
        Task<bool> ChangePasswordAsync(ChangePasswordViewModel model, string token);

    }
}
