using FluentValidation;
using GoVisit.Domain;

namespace GoVisit.Validations;

public class AppointmentsForUserValidator : AbstractValidator<AppointmentsForUser>
{
    public AppointmentsForUserValidator(IUserRepository repo)
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .Must( (id) => repo.Get(id).Result is not null)
            .WithMessage("User does not exist.");
    }
}

public class CancelMeetingRequestValidator : AbstractValidator<CancelMeetingRequest>
{
    public CancelMeetingRequestValidator(IUserRepository repo)
    {
        RuleFor(x => x.UserId)
            .NotEmpty();

        RuleFor(x => x.UserId)
            .Must((id) => repo.Get(id).Result is not null)
            .WithMessage("User does not exist.");
    }
}
