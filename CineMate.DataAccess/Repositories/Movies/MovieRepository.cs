using CineMate.Data.DbContexts;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Movies;

public class MovieRepository : Repository<Movie>, IMovieRepository
{
    public MovieRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}