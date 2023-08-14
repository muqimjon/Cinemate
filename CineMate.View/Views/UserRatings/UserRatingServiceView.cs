using CineMate.Service.DTOs;
using CineMate.Service.Interfaces;
using CineMate.Services.Ratings;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;

namespace CineMate.View.Views;

public class UserRatingServiceView : ServiceView<UserRatingService, UserRatingCreationDto, UserRatingUpdateDto, UserRatingResultDto>, IUserRatingServiceView
{
    private readonly IUserRatingService userRatingService;

    public UserRatingServiceView(UserRatingService userRatingService) : base(userRatingService)
    {
        this.userRatingService = userRatingService;
    }

    public async Task CreateAsync(long id)
    {
        UserRatingCreationDto dto = new() { UserId = id };

        Console.Write("MovieId: ");
        dto.MovieId = long.Parse(Console.ReadLine()!);

        Console.Write("Comment: ");
        dto.Comment = Console.ReadLine();

        Console.Write("Rating (0-10): ");
        dto.Rating = int.Parse(Console.ReadLine()!);

        var result = await userRatingService.CreateAsync(dto);
        Console.WriteLine(result.Message);
    }
}
