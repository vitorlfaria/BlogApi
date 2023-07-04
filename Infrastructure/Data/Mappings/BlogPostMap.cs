using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Mappings;

public class BlogPostMap : IEntityTypeConfiguration<BlogPost>
{
    public void Configure(EntityTypeBuilder<BlogPost> builder)
    {
        builder.ToTable(name: "BlogPost", schema: "dbo");
        builder.HasKey(q => q.Id);

        builder.Property(c => c.Title).IsRequired();
        builder.Property(c => c.Content).IsRequired();
        builder.Property(c => c.AuthorId).IsRequired();
        builder.Property(c => c.CreatedAt).HasDefaultValueSql("GETDATE()");
        
        builder.HasOne(q => q.Author).WithMany().HasForeignKey(q => q.AuthorId).OnDelete(DeleteBehavior.Restrict);
    }
}