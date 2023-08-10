using CineMate.Data.DbContexts;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities.Movies;

namespace CineMate.Data.IRepositories.Movies;

public class MovieActorRepository : Repository<MovieActor>, IMovieActorRepository
{
    public MovieActorRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }
}