namespace CineMate.Domain.Entities;

public class UserRating : Auditable
{
    public int Rating { get; set; }
    public string? Comment { get; set; }

    public long UserId { get; set; }
    public User User { get; set; } = default!;

    public long MovieId { get; set; }
    public Movie Movie { get; set; } = default!;
}
