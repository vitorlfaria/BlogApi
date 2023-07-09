using Application.DataTransferObjects;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
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
        
        public UserController(UserManager<User> userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        } 
        
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.Users);
        }
        
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

            return NoContent();
        }
    }
}
