using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable(name: "User", schema: "dbo");
        builder.HasKey(q => q.Id);

        builder.Property(c => c.Name).IsRequired();
        builder.Property(c => c.Email).IsRequired();
        builder.Property(c => c.Password).IsRequired();
    }
}