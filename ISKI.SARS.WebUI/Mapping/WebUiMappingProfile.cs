using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.WebUI.ViewModels.ReportTemplates;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.SARS.WebUI.ViewModels.OperationClaims;
using ISKI.Core.Security.Dtos;
using ISKI.SARS.WebUI.ViewModels.Auths;

namespace ISKI.SARS.WebUI.Mapping;

public class WebUiMappingProfile : Profile
{
    public WebUiMappingProfile()
    {
        CreateMap<GetReportTemplateDto, ReportTemplateVm>().ReverseMap();
        CreateMap<OperationClaimDto, OperationClaimVm>().ReverseMap();
        CreateMap<LoginDto, LoginVm>().ReverseMap();
        CreateMap<RegisterDto, RegisterVm>().ReverseMap();
    }
}
