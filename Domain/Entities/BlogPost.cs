namespace Domain.Entities;

public class BlogPost : Entity
{
    public string Title { get; set; }
    public string Content { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; }
    public List<Tag> Tags { get; set; }
}