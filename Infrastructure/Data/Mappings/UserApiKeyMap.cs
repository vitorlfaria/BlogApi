using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class UserApiKeyMap : IEntityTypeConfiguration<UserApiKey>
{
    public void Configure(EntityTypeBuilder<UserApiKey> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Value).IsRequired();
        builder.HasIndex(x => x.Value).IsUnique();
        builder.Property(x => x.UserId).IsRequired();
        builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
    }
}