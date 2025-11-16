using GoVisit.Domain;
using MediatR;

namespace Core.Commands;

public record AddUserCommand(User User) : IRequest<Unit>;

public class AddUserCommandCommandHandler : IRequestHandler<AddUserCommand, Unit>
{
    private readonly IUserRepository _repository;


    public AddUserCommandCommandHandler(IUserRepository repository)
        => _repository = repository;


    public async Task<Unit> Handle(AddUserCommand request, CancellationToken cancellationToken){
        await _repository.Add(request.User);
        return Unit.Value;
    }

    
}