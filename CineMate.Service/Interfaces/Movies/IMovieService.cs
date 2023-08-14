using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces.Commons;

namespace CineMate.Service.Interfaces;

public interface IMovieService : IServiceInterface<MovieCreationDto, MovieUpdateDto, MovieResultDto>
{
    Response<IEnumerable<MovieResultDto>> GetByGenreIdAsync(long id);
}
