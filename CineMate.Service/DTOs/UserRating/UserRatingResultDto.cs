using CineMate.Domain.Entities;

namespace CineMate.Service.DTOs;

public class UserRatingResultDto
{
    public long Id { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; }
}