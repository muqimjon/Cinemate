using CineMate.Service.DTOs;
using CineMate.Service.Interfaces.Commons;

namespace CineMate.Service.Interfaces.Products;

public interface IUserRatingService : IServiceInterface<UserRatingCreationDto, UserRatingUpdateDto, UserRatingResultDto>
{
}
