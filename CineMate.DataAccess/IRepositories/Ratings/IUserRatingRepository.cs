using CineMate.Data.IRepositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Ratings;

public interface IUserRatingRepository : IRepository<UserRating>
{
    IQueryable<UserRating> GetByMovieId(long id);
}
