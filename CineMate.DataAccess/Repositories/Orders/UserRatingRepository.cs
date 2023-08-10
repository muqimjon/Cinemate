using CineMate.Data.DbContexts;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Ratings;

public class UserRatingRepository : Repository<UserRating>, IUserRatingRepository
{
    public UserRatingRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}
