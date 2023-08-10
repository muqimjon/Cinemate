using CineMate.Domain.Enums;

namespace CineMate.Domain.Entities;

public class User : Auditable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
