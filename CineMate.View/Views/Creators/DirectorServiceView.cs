using CineMate.Service.DTOs;
using CineMate.Services.Creators;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;

namespace CineMate.View.Views.Creators;

public class DirectorServiceView : ServiceView<DirectorService, DirectorCreationDto, DirectorUpdateDto, DirectorResultDto>, IDirectorServiceView
{
    public DirectorServiceView(DirectorService directorService) : base(directorService)
    {
        
    }
}
