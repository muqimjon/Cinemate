using CineMate.Service.DTOs;
using CineMate.Service.Services.Movies;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;
using System.Reflection;

namespace CineMate.View.Views;


public class MovieServiceView : ServiceView<MovieService, MovieCreationDto, MovieUpdateDto, MovieResultDto>, IMovieServiceView
{
    private readonly MovieService movieService;
    public MovieServiceView(MovieService movieService) : base(movieService)
    {
        this.movieService = movieService;
    }

    public void Top10()
    {
        var resultMovies = movieService.GetAll();
        if (!resultMovies.Data.Any())
        {
            Console.WriteLine("This Table is Empty");
            return;
        }

        var movies = resultMovies.Data.ToList().OrderBy(m => m.Rating).Take(10);
        PropertyInfo[] properties = typeof(MovieResultDto).GetProperties();

        foreach (var movie in movies)
            foreach (var property in properties)
                Console.Write($"{property.Name}: {property.GetValue(movie)} | ");

    }
}