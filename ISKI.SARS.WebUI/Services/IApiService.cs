using System.Threading.Tasks;
using ISKI.SARS.WebUI.Features.Login.Models;
using ISKI.SARS.WebUI.Features.Register.Models;
using ISKI.SARS.WebUI.Features.UserInfo.Models;
using ISKI.SARS.WebUI.Features.NewTemplate.Models;
using ISKI.SARS.WebUI.Features.NewReport.Models;
using ISKI.SARS.WebUI.Features.InstantValues.Models;

namespace ISKI.SARS.WebUI.Services
{
    public interface IApiService
    {
        Task<LoginResponse> LoginAsync(LoginViewModel model);
        Task<bool> RegisterAsync(RegisterViewModel model);
        Task<UserInfoViewModel?> GetUserInfoAsync(string userId, string token);
        Task<bool> UpdateUserInfoAsync(UserInfoViewModel model, string token);
        Task<bool> ChangePasswordAsync(ChangePasswordViewModel model, string token);
        Task<(bool IsSuccess, int StatusCode, string? Error)> CreateNewTemplateAsync(NewTemplateViewModel model, string token);
        Task<ReportTemplateListResponse> GetReportTemplatesAsync(ReportTemplateListRequest request, string token);
        Task<ReportTemplateListResponse> GetReportTemplateListAsync(ReportTemplateListRequest request, string token);
        Task<List<ReportTemplateTagItem>> GetReportTemplateTagListAsync(ReportTemplateTagListRequest request, string token);
        Task<InstantValueListResponse> GetInstantValuesAsync(InstantValueListRequest request, string token);


    }
}
