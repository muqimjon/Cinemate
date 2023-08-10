namespace CineMate.Service.DTOs;

public class MovieUpdateDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }
    public long DirectorId { get; set; }
    public long GenreId { get; set; }
}
