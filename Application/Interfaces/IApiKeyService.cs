using Application.DataTransferObjects;
using Domain.Entities;

namespace Application.Interfaces;

public interface IApiKeyService : IBaseService<UserApiKeyDto>
{
    UserApiKeyDto GenerateApiKey(User user);
}