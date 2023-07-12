using Application.DataTransferObjects;
using Domain.Entities;

namespace Application.Interfaces;

public interface IJwtService
{
    AuthenticationResponse CreateToken(User user);
}