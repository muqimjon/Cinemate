using CineMate.Service.DTOs;
using CineMate.Services.Ratings;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;

namespace CineMate.View.Views;

public class UserRatingServiceView : ServiceView<UserRatingService, UserRatingCreationDto, UserRatingUpdateDto, UserRatingResultDto>, IUserRatingServiceView
{
    public UserRatingServiceView(UserRatingService userRatingService) : base(userRatingService)
    {
    }
}
