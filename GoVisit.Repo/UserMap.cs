using GoVisit.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MongoDB.EntityFrameworkCore.Extensions;

namespace GoVisit.Repo;
public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToCollection("users").HasKey(e => e.UserId);
        builder.Property(p => p.UserId).HasElementName("_id").IsRequired();
        builder.Property(p => p.Name).HasElementName("name");
        builder.Property(p => p.Email).HasElementName("email");
        builder.Property(p => p.Phone).HasElementName("phone_number");

    }
}
