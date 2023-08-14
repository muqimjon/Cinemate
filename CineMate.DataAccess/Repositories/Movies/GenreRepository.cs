using CineMate.Data.DbContexts;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Movies;

public class GenreRepository : Repository<Genre>, IGenreRepository
{
    public GenreRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
