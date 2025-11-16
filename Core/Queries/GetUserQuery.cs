using GoVisit.Domain;
using MediatR;

namespace Core.Queries;

public record GetUserQuery(long Id) : IRequest<User?>;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, User?>
{
    private readonly IUserRepository _repository;


    public GetUserQueryHandler(IUserRepository repository)
        => _repository = repository;


    public async Task<User?> Handle(GetUserQuery request, CancellationToken cancellationToken) =>
      (await _repository.Get(request.Id));

}