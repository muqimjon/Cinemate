namespace CineMate.Domain.Entities;

public class Movie : Auditable
{
    public decimal Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Title { get; set; } = string.Empty;

    public long DirectorId { get; set; }
    public Director Director { get; set; } = default!;

    public List<Actor> Actors { get; set; } = default!;
}
