using CineMate.Service.DTOs;
using CineMate.Service.Interfaces.Commons;

namespace CineMate.Service.Interfaces;

public interface IUserRatingService : IServiceInterface<UserRatingCreationDto, UserRatingUpdateDto, UserRatingResultDto>
{
}
