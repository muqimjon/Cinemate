using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces.Commons;

namespace CineMate.Service.Interfaces.Users;

public interface IUserService : IServiceInterface<UserCreationDto, UserUpdateDto, UserResultDto>
{
    Task<Response<UserResultDto>> GetByPhoneAsync(string phone);
    Task<Response<UserResultDto>> GetByEmailAsync(string email);
}
