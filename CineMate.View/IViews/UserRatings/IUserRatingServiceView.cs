using CineMate.View.IViews.Commons;

namespace CineMate.View.IViews;

public interface IUserRatingServiceView : IServiceView
{
    Task CreateAsync(long id);
}
