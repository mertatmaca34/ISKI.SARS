using FluentValidation;
using ISKI.SARS.Application.Features.SystemSettings.Constants;

namespace ISKI.SARS.Application.Features.SystemSettings.Commands.WriteSystemSetting;

public class WriteSystemSettingCommandValidator : AbstractValidator<WriteSystemSettingCommand>
{
    public WriteSystemSettingCommandValidator()
    {
        RuleFor(x => x.OpcServerUrl)
            .NotEmpty().WithMessage(SystemSettingMessages.OpcServerUrlCannotBeEmpty);

        RuleFor(x => x.SessionTimeout)
            .GreaterThan(0).WithMessage(SystemSettingMessages.SessionTimeoutMustBePositive);
    }
}
