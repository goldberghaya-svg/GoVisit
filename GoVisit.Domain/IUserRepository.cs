
namespace GoVisit.Domain;

public interface IUserRepository
{
    Task Add(User user);
    Task<User?> Get(long id);
}
