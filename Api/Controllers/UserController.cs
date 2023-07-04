using Application.DataTransferObjects;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
        
        [HttpGet("{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }
        
        [HttpGet("{email}")]
        public IActionResult Get(string email)
        {
            var user = _userService.GetByEmail(email);
            return Ok(user);
        }
        
        [HttpPost]
        public IActionResult Post([FromBody] UserDto userDto)
        {
            _userService.Add(userDto);
            return Ok("User created successfully");
        }
        
        [HttpPut]
        public IActionResult Put([FromBody] UserDto userDto)
        {
            _userService.Update(userDto);
            return Ok("User updated successfully");
        }
        
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Remove(id);
            return Ok("User deleted successfully");
        }
    }
}
