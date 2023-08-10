namespace CineMate.Service.DTOs;

public class MovieActorUpdateDto
{
    public long Id { get; set; }
    public long MovieId { get; set; }
    public long ActorId { get; set; }
}