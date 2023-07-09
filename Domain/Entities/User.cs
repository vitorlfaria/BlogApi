using System.ComponentModel;
using Microsoft.AspNetCore.Identity;

namespace Domain.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}