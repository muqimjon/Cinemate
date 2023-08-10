namespace CineMate.Service.DTOs;

public class MovieCreationDto
{
    public string Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public long DirectorId { get; set; }
    public long GenreId { get; set; }
    public long AddressId { get; set; }
}