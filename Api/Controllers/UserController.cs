using Application.DataTransferObjects;
using Application.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userService;
        
        public UserController(UserManager<IdentityUser> userService)
        {
            _userService = userService;
        } 
        
        [HttpGet("{username}")]
        public async Task<IActionResult> Get(string username)
        {
            var user = await _userService.FindByNameAsync(username);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var result = _userService.CreateAsync(
                new IdentityUser() {Email = userDto.Email, UserName = userDto.Email},
                userDto.Password
            );

            if (!result.IsCompletedSuccessfully)
            {
                return BadRequest(result.Exception);
            }

            userDto.Password = null;
            return Created("User created successfully", userDto);
        } 
    }
}
