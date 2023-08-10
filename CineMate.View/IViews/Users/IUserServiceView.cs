using CineMate.View.IViews.Commons;

namespace CineMate.View.IViews;

public interface IUserServiceView : IServiceView
{
    Task GetByEmail();
    Task GetByPhone();
}
