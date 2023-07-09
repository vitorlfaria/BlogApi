using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Application.DataTransferObjects;

public class BlogPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string AuthorId { get; set; }
    public UserDto Author { get; set; }
    public List<Tag> Tags { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}