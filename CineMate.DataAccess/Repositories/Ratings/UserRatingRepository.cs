using CineMate.Data.DbContexts;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Ratings;

public class UserRatingRepository : Repository<UserRating>, IUserRatingRepository
{
    private readonly AppDbContext appDbContext;
    public UserRatingRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public IQueryable<UserRating> GetByMovieId(long id)
    {
        var movies = appDbContext.UserRatings.Where(r => r.MovieId == id);
        return movies;
    }
}
