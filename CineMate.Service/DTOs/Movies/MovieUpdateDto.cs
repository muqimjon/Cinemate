using CineMate.Domain.Enums;

namespace CineMate.Service.DTOs;

public class MovieUpdateDto
{
    public long Id { get; set; }
    public decimal Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public long DirectorId { get; set; }
}
