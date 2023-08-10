using CineMate.Domain.Entities;

namespace CineMate.Service.DTOs;

public class MovieActorResultDto
{
    public long Id { get; set; }
    public long MovieId { get; set; }

    public long ActorId { get; set; }
}
