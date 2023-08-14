namespace CineMate.Service.DTOs;

public class UserRatingCreationDto
{
    public long MovieId { get; set; }
    public string? Comment { get; set; }
    public long UserId { get; set; }
    public int Rating { get; set; }
}
