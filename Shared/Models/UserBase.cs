using System.Text.Json.Serialization;

namespace Shared.Models;
public abstract class UserBase
{
       public Guid Id { get; set; }
       public string Name { get; set; }
       public string Surname { get; set; }
       public string Email { get; set; }    
       public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
       public UserRole Role { get; set; }

}

