
namespace GoVisit.Domain;

public interface IAppiontmentsForUserRepository
{
    Task Update(AppointmentsForUser appointmentsForUser);
    Task Add(AppointmentsForUser appointmentsForUser);
    Task<List<AppointmentsForUser>> Get();
}
