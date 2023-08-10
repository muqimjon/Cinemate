using CineMate.Data.DbContexts;
using CineMate.Data.IRepositories;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.Repositories;

public class AddressRepository : Repository<Address>, IAddressRepository
{
    public AddressRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}
