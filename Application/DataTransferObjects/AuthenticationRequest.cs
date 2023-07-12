using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObjects;

public class AuthenticationRequest
{
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
}