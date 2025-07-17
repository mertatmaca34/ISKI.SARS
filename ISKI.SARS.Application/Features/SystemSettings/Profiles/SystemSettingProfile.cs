using AutoMapper;
using ISKI.SARS.Domain.Entities;
using ISKI.SARS.Application.Features.SystemSettings.Dtos;

namespace ISKI.SARS.Application.Features.SystemSettings.Profiles;

public class SystemSettingProfile : Profile
{
    public SystemSettingProfile()
    {
        CreateMap<SystemSetting, SystemSettingDto>();
    }
}
