using CineMate.View.IViews.Commons;

namespace CineMate.View.IViews;

public interface IGenreServiceView : IServiceView
{
    Task GetMovie();
}
