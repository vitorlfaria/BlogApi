using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Domain.Entities;

namespace Application.DataTransferObjects;

public class UserApiKeyDto
{
    [JsonIgnore]
    public Guid Id { get; set; }
    
    public string Value { get; set; }
    
    [JsonIgnore]
    public string UserId { get; set; }
    
    [JsonIgnore]
    public User User { get; set; }
    
}