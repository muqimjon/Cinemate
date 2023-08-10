namespace CineMate.View.IViews.Commons;

public interface IUnitOfView
{
    IMovieServiceView MovieServiceView { get; }
    IGenreServiceView GenreServiceView { get; }
    IActorServiceView ActorServiceView { get; }
    IMovieActorServiceView MovieActorServiceView { get; }
    IUserRatingServiceView UserRatingServiceView { get; }
    IDirectorServiceView DirectorServiceView { get; }
    IAddressServiceView AddressServiceView { get; }
    IUserServiceView UserServiceView { get; }
}
