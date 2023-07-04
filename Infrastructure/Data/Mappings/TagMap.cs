using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class TagMap : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.ToTable("Tag", "dbo");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Name).IsRequired();
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
    }
}