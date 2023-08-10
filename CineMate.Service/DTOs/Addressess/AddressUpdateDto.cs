namespace CineMate.Service.DTOs;

public class AddressUpdateDto
{
    public long Id { get; set; }
    public string Country { get; set; } = default!;
    public string CountryCode { get; set; } = default!;
}
