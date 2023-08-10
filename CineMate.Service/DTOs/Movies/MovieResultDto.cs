using CineMate.Domain.Entities;

namespace CineMate.Service.DTOs;

public class MovieResultDto
{
    public long Id { get; set; }
    public decimal Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Title { get; set; } = string.Empty;
    public List<Actor> Actors { get; set; } = default!;
    public virtual Director Director { get; set; } = default!;
}