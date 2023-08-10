using CineMate.Service.DTOs;
using CineMate.Service.Interfaces.Commons;

namespace CineMate.Service.Interfaces;

public interface IGenreService : IServiceInterface<GenreCreationDto, GenreUpdateDto, GenreResultDto>
{
}
