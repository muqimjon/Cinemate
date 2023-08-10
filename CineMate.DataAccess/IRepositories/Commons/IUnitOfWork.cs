using CineMate.Data.IRepositories.Users;
using CineMate.Data.IRepositories.Ratings;
using CineMate.Data.IRepositories.Movies;
using CineMate.Data.IRepositories.Creators;

namespace CineMate.Data.IRepositories.Commons;

public interface IUnitOfWork : IDisposable
{
    IMovieRepository MovieRepository { get; }
    IGenreRepository GenreRepository { get; }
    IUserRatingRepository UserRatingRepository { get; }
    IActorRepository ActorRepository { get; }
    IDirectorRepository DirectorRepository { get; }
    IUserRepository UserRepository { get; }
    IAddressRepository AddressRepository { get; }  
    Task SaveAsync();
}
