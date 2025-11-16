using GoVisit.Domain;
using MediatR;

namespace Core.Queries;

public record GetAppointmentsForUserQuery(long Id) : IRequest<List<Appointments>?>;

public class GetAppointmentsForUserQueryHandler : IRequestHandler<GetAppointmentsForUserQuery, List<Appointments>?>
{
    private readonly IAppiontmentsForUserRepository _repository;


    public GetAppointmentsForUserQueryHandler(IAppiontmentsForUserRepository repository)
        => _repository = repository;


    public async Task<List<Appointments>?> Handle(GetAppointmentsForUserQuery request, CancellationToken cancellationToken) =>
      (await _repository.Get()).Where(a => a.UserId == request.Id)
           .SelectMany(a => a.Appointments).ToList();

}