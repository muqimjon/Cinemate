using CineMate.Service.DTOs;
using CineMate.Service.Services.Movies;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;

namespace CineMate.View.Views;

public class MovieServiceView : ServiceView<MovieService, MovieCreationDto, MovieUpdateDto, MovieResultDto>, IMovieServiceView
{
    public MovieServiceView(MovieService movieService) : base(movieService)
    {
    }
}
