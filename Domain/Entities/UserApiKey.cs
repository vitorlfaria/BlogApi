using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index(nameof(Value), IsUnique = true)]
public class UserApiKey : Entity
{
    [Required]
    public string Value { get; set; }
    
    [JsonIgnore]
    [Required]
    public string UserId { get; set; }
    
    [JsonIgnore]
    public User User { get; set; }
}