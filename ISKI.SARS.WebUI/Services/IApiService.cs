using System.Threading.Tasks;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Services
{
    public interface IApiService
    {
        Task<LoginResponse> LoginAsync(LoginViewModel model);
        Task<bool> RegisterAsync(RegisterViewModel model);
    }
}
