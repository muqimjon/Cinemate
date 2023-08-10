namespace CineMate.Domain.Entities;

public class Actor : Auditable
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}
