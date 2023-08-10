using CineMate.Domain.Entities;

namespace CineMate.Service.DTOs;

public class UserRatingResultDto
{
    public long Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public virtual User User { get; set; } = default!;
    public virtual Movie Movie { get; set; } = default!;
}