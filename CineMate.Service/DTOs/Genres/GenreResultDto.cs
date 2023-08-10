using CineMate.Domain.Entities;

namespace CineMate.Service.DTOs;

public class GenreResultDto
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Movie> Products { get; set; } = default!;
}
