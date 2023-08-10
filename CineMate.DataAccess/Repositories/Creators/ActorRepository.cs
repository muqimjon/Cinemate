using CineMate.Data.DbContexts;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Creators;

public class ActorRepository : Repository<Actor>, IActorRepository
{
    public ActorRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        
    }
}