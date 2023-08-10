namespace CineMate.Service.DTOs;

public class UserRatingCreationDto
{
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public long UserId { get; set; }
    public long MovieId { get; set; }
}
