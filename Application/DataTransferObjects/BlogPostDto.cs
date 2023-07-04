using Domain.Entities;

namespace Application.DataTransferObjects;

public class BlogPostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }
    public virtual User Author { get; set; }
    public virtual List<Tag> Tags { get; set; }
}