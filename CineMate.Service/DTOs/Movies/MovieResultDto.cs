using CineMate.Domain.Entities;

namespace CineMate.Service.DTOs;

public class MovieResultDto
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
}