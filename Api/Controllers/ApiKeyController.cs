using Application.DataTransferObjects;
using Application.Interfaces;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ApiKeyController : ControllerBase
{
    private readonly IApiKeyService _apiKeyService;
    private readonly UserManager<User> _userService;

    public ApiKeyController(IApiKeyService apiKeyService, UserManager<User> userService)
    {
        _apiKeyService = apiKeyService;
        _userService = userService;
    }
    
    [HttpPost("ApiKey")]
    public async Task<ActionResult<string>> CreateApiKey([FromBody] AuthenticationRequest request)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
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
        
        var token = _apiKeyService.GenerateApiKey(user);

        return Ok(token);
    }
}