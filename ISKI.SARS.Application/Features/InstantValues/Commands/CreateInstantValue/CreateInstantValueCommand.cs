using ISKI.SARS.Application.Features.InstantValues.Dtos;
using MediatR;

namespace ISKI.SARS.Application.Features.InstantValues.Commands.CreateInstantValue;

public class CreateInstantValueCommand : IRequest<GetInstantValueDto>
{
    public int ReportTemplateTagId { get; set; }
    public DateTime Timestamp { get; set; }
    public string Value { get; set; } = string.Empty;
    public bool Status { get; set; }
}