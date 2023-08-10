using CineMate.Service.Services.ProductCategories;
using CineMate.Service.Services.Movies;
using CineMate.Service.Services.Users;
using CineMate.View.IViews.Commons;
using CineMate.View.IViews;

namespace CineMate.View.Views.Commons;

public class UnitOfView : IUnitOfView
{
    public UnitOfView()
    {
        UserServiceView = new UserServiceView(new UserService());
        ProductCategoryServiceView = new GenreServiceView(new GenreService());
        ProductServiceView = new MovieServiceView(new MovieService());
    }

    public IUserServiceView UserServiceView { get; }
    public IMovieServiceView ProductServiceView { get; }
    public IGenreServiceView ProductCategoryServiceView { get; }
}
