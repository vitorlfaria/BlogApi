using Application.DataTransferObjects;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userService;
        private readonly IMapper _mapper;
        private readonly IJwtService _jwtService;
        
        public UserController(UserManager<User> userService, IMapper mapper, IJwtService jwtService)
        {
            _userService = userService;
            _mapper = mapper;
            _jwtService = jwtService;
        } 
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.Users);
        }
        
        [Authorize]
        [HttpGet("{username}")]
        public async Task<IActionResult> GetByUserName(string username)
        {
            var user = await _userService.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = await _userService.CreateAsync(
                _mapper.Map<User>(userDto),
                userDto.Password
            );

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            userDto.Password = null;
            return CreatedAtAction("GetByUserName", new { username = userDto.UserName }, userDto);
        } 
        
        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string username)
        {
            var user = await _userService.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            var result = await _userService.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("User deleted successfully");
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
}
