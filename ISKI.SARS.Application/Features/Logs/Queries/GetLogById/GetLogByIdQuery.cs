using ISKI.SARS.Application.Features.Logs.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.Logs.Queries.GetLogById;

public record GetLogByIdQuery(int Id) : IRequest<LogDto>;
