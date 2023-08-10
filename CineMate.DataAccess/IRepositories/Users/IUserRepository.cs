using CineMate.Data.IRepositories.Commons;
using CineMate.Domain.Entities;

namespace CineMate.Data.IRepositories.Users;

public interface IUserRepository : IRepository<User>
{
    Task<User> GetByEmailAsync(string email);
    Task<User> GetByPhoneAsync(string phone);
}
