using CineMate.Data.DbContexts;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Creators;

public class DirectorRepository : Repository<Director>, IDirectorRepository
{
    public DirectorRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}