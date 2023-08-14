using Microsoft.EntityFrameworkCore;
using CineMate.Data.DbContexts;
using CineMate.Data.IRepositories.Users;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    private readonly AppDbContext appDbContext;
    public UserRepository(AppDbContext appDbContext) : base(appDbContext)
    {
        this.appDbContext = appDbContext;
    }

    public async Task<User> GetByEmailAsync(string email)
        => await appDbContext.Users
            .FirstOrDefaultAsync(x => x.Email.ToLower().Equals(email.ToLower())) ?? default!;

    public async Task<User> GetByPhoneAsync(string phone)
        => await appDbContext.Users
            .FirstOrDefaultAsync(x => x.Phone.Trim().Equals(phone.Trim())) ?? default!;
}
