using GoVisit.Domain;
using MediatR;

namespace Core.Commands;

public record AddAppointmentsForUserCommand(AppointmentsForUser AppointmentsForUser) : IRequest<Unit>;

public class AddAppointmentsForUserCommandHandler : IRequestHandler<AddAppointmentsForUserCommand, Unit>
{
    private readonly IAppiontmentsForUserRepository _repository;


    public AddAppointmentsForUserCommandHandler(IAppiontmentsForUserRepository repository)
        => _repository = repository;


    public async Task<Unit> Handle(AddAppointmentsForUserCommand request, CancellationToken cancellationToken){
        await _repository.Add(request.AppointmentsForUser);
        return Unit.Value;

    }

    
}