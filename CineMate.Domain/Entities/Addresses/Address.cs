namespace CineMate.Domain.Entities;

public class Address : Auditable
{
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string CountryCode { get; set; } = default!;
}
