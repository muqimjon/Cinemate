using CineMate.Data.DbContexts;
using CineMate.Data.IRepositories;
using CineMate.Data.IRepositories.Users;
using CineMate.Data.IRepositories.Movies;
using CineMate.Data.IRepositories.Ratings;
using CineMate.Data.IRepositories.Commons;
using CineMate.Data.IRepositories.Creators;

namespace CineMate.Data.Repositories.Commons;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext appDbContext;
    public UnitOfWork()
    {
        appDbContext = new AppDbContext();
        MovieRepository = new MovieRepository(appDbContext);
        GenreRepository = new GenreRepository(appDbContext);
        AddressRepository = new AddressRepository(appDbContext);
        UserRatingRepository = new UserRatingRepository(appDbContext);
        DirectorRepository = new DirectorRepository(appDbContext);
        ActorRepository = new ActorRepository(appDbContext);
        UserRepository = new UserRepository(appDbContext);
        Dispose();
    }

    public IMovieRepository MovieRepository { get; }
    public IGenreRepository GenreRepository { get; }
    public IAddressRepository AddressRepository { get; }
    public IUserRatingRepository UserRatingRepository { get; }
    public IDirectorRepository DirectorRepository { get; }
    public IActorRepository ActorRepository { get; }
    public IUserRepository UserRepository { get; }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async Task SaveAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
}
