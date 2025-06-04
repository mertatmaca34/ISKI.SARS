using System.Threading.Tasks;
using ISKI.SARS.WebUI.Models;

namespace ISKI.SARS.WebUI.Services
{
    public interface IApiService
    {
        Task<string> LoginAsync(LoginViewModel model);
        Task<bool> RegisterAsync(RegisterViewModel model);

        // User operations
        Task<IEnumerable<UserViewModel>> GetUsersAsync();
        Task<UserViewModel?> GetUserByIdAsync(Guid id);
        Task<bool> CreateUserAsync(UserViewModel model);
        Task<bool> UpdateUserAsync(UserViewModel model);
        Task<bool> DeleteUserAsync(Guid id);

        // Tag operations
        Task<IEnumerable<TagViewModel>> GetTagsAsync(int templateId);
        Task<TagViewModel?> GetTagByIdAsync(int id);
        Task<bool> CreateTagAsync(TagViewModel model);
        Task<bool> UpdateTagAsync(TagViewModel model);
        Task<bool> DeleteTagAsync(int id);

        // Report template operations
        Task<IEnumerable<ReportTemplateViewModel>> GetReportTemplatesAsync();
        Task<ReportTemplateViewModel?> GetReportTemplateByIdAsync(int id);
        Task<bool> CreateReportTemplateAsync(ReportTemplateViewModel model);

        Task<byte[]> GetReportPdfAsync(int templateId);
        Task<byte[]> GetReportExcelAsync(int templateId);
    }
}
