using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class BlogPost : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public User Author { get; set; }
    
    [NotMapped]
    public List<Tag> Tags { get; set; }
}