using GoVisit.Domain;
using Microsoft.EntityFrameworkCore;

namespace GoVisit.Repo;

public class AppiontmentsForUserRepository : IAppiontmentsForUserRepository
{
    private readonly AppointmentsContext _db;

    public AppiontmentsForUserRepository(AppointmentsContext context) =>
        _db = context;

    public async Task<List<AppointmentsForUser>> Get() =>
     await _db.AppointmentsForUser.ToListAsync();
    
    public async Task Add(AppointmentsForUser appointmentsForUser)
    {
        _db.AppointmentsForUser.Add(appointmentsForUser);
        await _db.SaveChangesAsync();       
    }

    public async Task Update(AppointmentsForUser appointmentsForUser)
    {
        _db.AppointmentsForUser.Update(appointmentsForUser);
        await _db.SaveChangesAsync();
    }

}
