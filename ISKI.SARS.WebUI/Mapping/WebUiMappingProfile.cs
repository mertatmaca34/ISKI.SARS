using AutoMapper;
using ISKI.SARS.Application.Features.ReportTemplates.Dtos;
using ISKI.SARS.WebUI.ViewModels.ReportTemplates;
using ISKI.SARS.Application.Features.OperationClaims.Dtos;
using ISKI.SARS.WebUI.ViewModels.OperationClaims;
using ISKI.Core.Security.Dtos;
using ISKI.SARS.WebUI.ViewModels.Auths;
using ISKI.SARS.Application.Features.Users.Dtos;
using ISKI.SARS.Application.Features.Users.Commands.Create;
using ISKI.SARS.Application.Features.Users.Commands.Update;
using ISKI.SARS.WebUI.ViewModels.Users;
using ISKI.SARS.Application.Features.Users.Commands.ChangePassword;

namespace ISKI.SARS.WebUI.Mapping;

public class WebUiMappingProfile : Profile
{
    public WebUiMappingProfile()
    {
        CreateMap<GetReportTemplateDto, ReportTemplateVm>().ReverseMap();
        CreateMap<OperationClaimDto, OperationClaimVm>().ReverseMap();
        CreateMap<LoginDto, LoginVm>().ReverseMap();
        CreateMap<RegisterDto, RegisterVm>().ReverseMap();
        CreateMap<UserDto, UserVm>().ReverseMap();
        CreateMap<CreateUserCommand, UserVm>().ReverseMap();
        CreateMap<UpdateUserCommand, UserVm>().ReverseMap();
        CreateMap<ChangePasswordCommand, ChangePasswordVm>().ReverseMap();
    }
}
