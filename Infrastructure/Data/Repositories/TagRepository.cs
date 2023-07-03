using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repositories;

public class TagRepository : BaseRepository<Tag>, ITagRepository
{
    public TagRepository(BaseContext context) : base(context)
    {
    }
}