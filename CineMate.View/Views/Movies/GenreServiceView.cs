using CineMate.Service.DTOs;
using CineMate.Service.Services.ProductCategories;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;

namespace CineMate.View.Views;

public class GenreServiceView : ServiceView<GenreService, GenreCreationDto, GenreUpdateDto, GenreResultDto>, IGenreServiceView
{
    public GenreServiceView(GenreService genreService) : base(genreService)
    {
    }
}
