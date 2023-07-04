using Application.DataTransferObjects;

namespace Application.Interfaces;

public interface IUserService : IBaseService<UserDto>
{
    UserDto GetByEmail(string email);
    UserDto GetById(Guid id);
}