using ISKI.SARS.Application.Features.SystemSettings.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.SystemSettings.Queries.GetSystemSettings;

public class GetSystemSettingsQuery : IRequest<SystemSettingDto>
{
}
