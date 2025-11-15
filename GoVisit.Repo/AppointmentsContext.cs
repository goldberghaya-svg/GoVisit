using GoVisit.Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using System.Reflection.Metadata;

namespace GoVisit.Repo;

public class AppointmentsContext : DbContext
{
    public AppointmentsContext(DbContextOptions<AppointmentsContext> options) : base(options) { }

    public DbSet<AppointmentsForUser> AppointmentsForUser { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new AppointmentsForUserMap());
     
    }

}
