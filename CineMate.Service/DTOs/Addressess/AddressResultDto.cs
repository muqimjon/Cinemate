namespace CineMate.Service.DTOs;

public class AddressResultDto
{
    public long Id { get; set; }
    public string City { get; set; } = default!;
    public string Country { get; set; } = default!;
    public string CountryCode { get; set; } = default!;
}
