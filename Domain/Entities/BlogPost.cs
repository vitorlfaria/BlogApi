using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class BlogPost : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }
    public IdentityUser Author { get; set; }
    
    [NotMapped]
    public List<Tag> Tags { get; set; }
}