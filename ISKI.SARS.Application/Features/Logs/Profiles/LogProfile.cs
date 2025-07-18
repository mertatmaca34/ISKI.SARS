using AutoMapper;
using ISKI.Core.Persistence.Paging;
using ISKI.SARS.Application.Features.Logs.Commands.CreateLog;
using ISKI.SARS.Application.Features.Logs.Commands.UpdateLog;
using ISKI.SARS.Application.Features.Logs.Dtos;
using ISKI.SARS.Domain.Entities;

namespace ISKI.SARS.Application.Features.Logs.Profiles;

public class LogProfile : Profile
{
    public LogProfile()
    {
        CreateMap<CreateLogCommand, LogEntry>();
        CreateMap<UpdateLogCommand, LogEntry>();
        CreateMap<LogEntry, LogDto>();
        CreateMap<PaginatedList<LogEntry>, PaginatedList<LogDto>>();
    }
}
