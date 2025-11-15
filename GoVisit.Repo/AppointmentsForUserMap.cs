using GoVisit.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace GoVisit.Repo;
public class AppointmentsForUserMap : IEntityTypeConfiguration<AppointmentsForUser>
{
    public void Configure(EntityTypeBuilder<AppointmentsForUser> builder)
    {

        builder.ToCollection("appointments_for_user").HasKey(e => e.UserId);
        builder.Property(e => e.UserId).HasElementName("_id").IsRequired();

    }

}
