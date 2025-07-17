using AutoMapper;
using ISKI.SARS.Application.Features.SystemSettings.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.SystemSettings.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SystemSettings, SystemSettingsDto>()
            .ForMember(d => d.DatabaseConnection, o => o.Ignore())
            .ForMember(d => d.RetentionDays, o => o.MapFrom(_ => 90))
            .ForMember(d => d.EmailNotifications, o => o.MapFrom(_ => true))
            .ForMember(d => d.SmsNotifications, o => o.MapFrom(_ => false))
            .ForMember(d => d.AlertThreshold, o => o.MapFrom(_ => 85))
            .ForMember(d => d.BackupEnabled, o => o.MapFrom(_ => true))
            .ForMember(d => d.BackupIntervalHours, o => o.MapFrom(_ => 24));
    }
}
