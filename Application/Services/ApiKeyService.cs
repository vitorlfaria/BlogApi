using Application.DataTransferObjects;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class ApiKeyService : BaseService<UserApiKey, UserApiKeyDto, IUserApiKeyRepository>, IApiKeyService
{
    public ApiKeyService(IUserApiKeyRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
    
    public UserApiKeyDto GenerateApiKey(User user)
    {
        var apiKey = new UserApiKey()
        {
            User = user,
            Value = GenerateKey(),
        };
        
        _repository.Add(apiKey);
        _repository.SaveChanges();

        return _mapper.Map<UserApiKeyDto>(apiKey);
    }
    
    private static string GenerateKey() => $"{Guid.NewGuid().ToString()}-{Guid.NewGuid().ToString()}";
}