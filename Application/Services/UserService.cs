using Application.DataTransferObjects;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces.Repositories;

namespace Application.Services;

public class UserService : BaseService<User, UserDto, IUserRepository>, IUserService
{
    public UserService(IMapper mapper, IUserRepository repository) : base(repository, mapper)
    {
        
    }
}