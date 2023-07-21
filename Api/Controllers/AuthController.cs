using Application.DataTransferObjects;
using Application.Interfaces;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IJwtService _jwtService;
    private readonly UserManager<User> _userService;

    public AuthController(IJwtService jwtService, UserManager<User> userService)
    {
        _jwtService = jwtService;
        _userService = userService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult<AuthenticationResponse>> CreateBearerToken(AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad credentials");
        }
    
        var user = await _userService.FindByNameAsync(request.UserName);
    
        if (user == null)
        {
            return BadRequest("Bad credentials");
        }
    
        var isPasswordValid = await _userService.CheckPasswordAsync(user, request.Password);
    
        if (!isPasswordValid)
        {
            return BadRequest("Bad credentials");
        }
    
        var token = _jwtService.CreateToken(user);
    
        return Ok(token);
    }
}
