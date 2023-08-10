using CineMate.Service.Services.Movies;
using CineMate.Service.Services.Users;
using CineMate.View.IViews.Commons;
using CineMate.View.IViews;
using CineMate.Services.Creators;
using CineMate.View.Views.Creators;
using CineMate.Services.Addresses;
using CineMate.Services.Ratings;

namespace CineMate.View.Views.Commons;

public class UnitOfView : IUnitOfView
{
    public UnitOfView()
    {
        GenreServiceView = new GenreServiceView(new GenreService());
        MovieServiceView = new MovieServiceView(new MovieService());
        ActorServiceView = new ActorServiceView(new ActorService());
        MovieActorServiceView = new MovieActorServiceView(new MovieActorService());
        UserRatingServiceView = new UserRatingServiceView(new UserRatingService());
        DirectorServiceView = new DirectorServiceView(new DirectorService());
        AddressServiceView = new AddressServiceView(new AddressService());
        UserServiceView = new UserServiceView(new UserService());
    }

    public IMovieServiceView MovieServiceView { get; }
    public IGenreServiceView GenreServiceView { get; }
    public IActorServiceView ActorServiceView { get; }
    public IMovieActorServiceView MovieActorServiceView { get; }
    public IUserRatingServiceView UserRatingServiceView { get; }
    public IDirectorServiceView DirectorServiceView { get; }
    public IAddressServiceView AddressServiceView { get; }
    public IUserServiceView UserServiceView { get; }
}
