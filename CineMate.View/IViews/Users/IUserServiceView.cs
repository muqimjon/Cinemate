using CineMate.Domain.Enums;
using CineMate.Service.DTOs;
using CineMate.View.IViews.Commons;

namespace CineMate.View.IViews;

public interface IUserServiceView : IServiceView
{
    Task GetByEmail();
    Task GetByPhone();
    Task<UserResultDto> SignIn();
    Task<UserResultDto> SignUp();
    Task<UserResultDto> ResetPasswordAsync();
    void GetInfo(UserResultDto dto);
    Task ChangeUserRoleAsync(UserRole role);
    Task<UserResultDto> UpdateInfoAsync(UserResultDto dto);
}
