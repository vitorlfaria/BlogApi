using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infrastructure.Data.Context;

namespace Infrastructure.Data.Repositories;

public class UserApiKeyRepository : BaseRepository<UserApiKey>, IUserApiKeyRepository
{
    public UserApiKeyRepository(BaseContext context) : base(context)
    {
    }
}