namespace CineMate.Service.DTOs;

public class UserRatingUpdateDto
{
    public long Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
    public long UserId { get; set; }
    public long MovieId { get; set; }
}
