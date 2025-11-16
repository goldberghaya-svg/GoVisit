using GoVisit.Domain;
using MediatR;

namespace Core.Commands;

public record CancelAppointmentRequestCommand(CancelAppointmentRequest CancelAppointmentRequest) : IRequest<Unit>;

public class CancelAppointmentRequestCommandHandler : IRequestHandler<CancelAppointmentRequestCommand, Unit>
{
    private readonly IAppiontmentsForUserRepository _repository;


    public CancelAppointmentRequestCommandHandler(IAppiontmentsForUserRepository repository)
        => _repository = repository;


    public async Task<Unit> Handle(CancelAppointmentRequestCommand request, CancellationToken cancellationToken){
        var appointmentsForUser = (await _repository.Get()).FirstOrDefault(a => a.UserId == request.CancelAppointmentRequest.UserId);
        appointmentsForUser.Appointments.RemoveAll(a => a.OfficeId == request.CancelAppointmentRequest.OfficeId);
        await _repository.Update(appointmentsForUser);
        return Unit.Value;

    }

    
}