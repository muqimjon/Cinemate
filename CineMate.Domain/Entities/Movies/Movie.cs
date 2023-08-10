namespace CineMate.Domain.Entities;

public class Movie : Auditable
{
    public decimal Rating { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Title { get; set; } = string.Empty;

    public long GenreId { get; set; }
    public virtual Genre Genre { get; set; } = default!;

    public long DirectorId { get; set; }
    public virtual Director Director { get; set; } = default!;

    public long AddressId { get; set; }
    public virtual Address Address { get; set; } = default!;
}
