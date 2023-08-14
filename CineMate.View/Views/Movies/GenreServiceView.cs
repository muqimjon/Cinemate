using CineMate.Service.DTOs;
using CineMate.Service.Interfaces;
using CineMate.Service.Services.Movies;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;
using System.Reflection;

namespace CineMate.View.Views;

public class GenreServiceView : ServiceView<GenreService, GenreCreationDto, GenreUpdateDto, GenreResultDto>, IGenreServiceView
{
    public readonly GenreService genreService;
    public GenreServiceView(GenreService genreService) : base(genreService)
    {
        this.genreService = genreService;
    }

    public async Task GetMovie()
    {
        var checkGenres = genreService.GetAll();
        if (!checkGenres.Data.Any())
        {
            Console.WriteLine("Empty");
            return;
        }

        var genres = checkGenres.Data;
        PropertyInfo[] properties = typeof(GenreResultDto).GetProperties();

        foreach (var item in genres)
        {
            foreach (var property in properties)
                Console.Write($"{property.Name}: {property.GetValue(item)} | ");
            Console.WriteLine();
        }

        var id = long.Parse(Console.ReadLine()!);
        var checkGenre = await genreService.GetByIdAsync(id);
        if (checkGenre.StatusCode != 200)
        {
            Console.WriteLine(checkGenre.Message);
            return;
        }

        IMovieService movieService = new MovieService();
        var checkMovies = movieService.GetByGenreIdAsync(id);
        if(checkMovies.StatusCode != 200)
        {
            Console.WriteLine("This Table is empty");
            return;
        }

        var movies = checkMovies.Data;
        PropertyInfo[] propertiesMovie = typeof(MovieResultDto).GetProperties();

        foreach (var item in movies)
        {
            foreach (var property in propertiesMovie)
                Console.Write($"{property.Name}: {property.GetValue(item)} | ");
            Console.WriteLine();
        }
    }   
}
