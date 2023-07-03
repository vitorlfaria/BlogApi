using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repositories;

public class BlogPostRepository : BaseRepository<BlogPost>, IBlogPostRepository
{
    public BlogPostRepository(BaseContext context) : base(context)
    {
        
    }
}