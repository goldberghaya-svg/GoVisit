using GoVisit.Domain;
using Microsoft.EntityFrameworkCore;

namespace GoVisit.Repo
{
    public class UserRepository : IUserRepository
    {

        private readonly AppointmentsContext _db;

        public UserRepository(AppointmentsContext db) =>
            _db = db;

        public async Task<User?> Get(long id) =>
            await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);

        public async Task Add(User user) {
         await _db.Users.AddAsync(user);
            _ = _db.SaveChangesAsync();
        }
           

    }
}
