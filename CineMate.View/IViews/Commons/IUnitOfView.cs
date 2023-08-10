namespace CineMate.View.IViews.Commons;

public interface IUnitOfView
{
    IUserServiceView UserServiceView { get; }
    IMovieServiceView ProductServiceView { get; }
    IGenreServiceView ProductCategoryServiceView { get; }
}
