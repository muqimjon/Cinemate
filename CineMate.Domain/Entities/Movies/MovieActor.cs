namespace CineMate.Domain.Entities.Movies;

public class MovieActor :Auditable
{
    public long MovieId { get; set; }
    public virtual Movie Movie { get; set; } = default!;

    public long ActorId { get; set; }
    public virtual Actor Actor { get; set; } = default!;
}
