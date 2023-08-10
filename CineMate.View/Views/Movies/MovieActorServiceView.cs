using CineMate.Service.DTOs;
using CineMate.Service.Services.Movies;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;
using System.Reflection;

namespace CineMate.View.Views;

public class MovieActorServiceView : ServiceView<MovieActorService, MovieActorCreationDto, MovieActorUpdateDto, MovieActorResultDto>, IMovieActorServiceView
{
    public MovieActorServiceView(MovieActorService MovieActorService) : base(MovieActorService)
    {
    }
}
