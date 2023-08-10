using CineMate.Service.DTOs;
using CineMate.Service.Interfaces.Commons;

namespace CineMate.Service.Interfaces.Creators;

public interface IDirectorService : IServiceInterface<DirectorCreationDto, DirectorUpdateDto, DirectorResultDto>
{
}
