using AutoMapper;
using CineMate.Data.IRepositories.Commons;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;
using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces;
using CineMate.Service.Mappers;

namespace CineMate.Service.Services.Movies;

public class MovieService : IMovieService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public MovieService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<MovieResultDto>> CreateAsync(MovieCreationDto dto)
    {
        var checkGenre = await unitOfWork.GenreRepository.GetByIdAsync(dto.GenreId);
        if (checkGenre is null)
            return new Response<MovieResultDto>()
            {
                StatusCode = 404,
                Message = "This Genre is not found"
            };

        var checkDirector = await unitOfWork.GenreRepository.GetByIdAsync(dto.GenreId);
        if (checkDirector is null)
            return new Response<MovieResultDto>()
            {
                StatusCode = 404,
                Message = "Director is not found"
            };

        var mapped = mapper.Map<Movie>(dto);
        await unitOfWork.MovieRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<MovieResultDto>(mapped);

        return new Response<MovieResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<MovieResultDto>> UpdateAsync(MovieUpdateDto dto)
    {
        var checkMovie = await unitOfWork.MovieRepository.GetByIdAsync(dto.Id);
        if (checkMovie is null)
            return new Response<MovieResultDto>()
            {
                StatusCode = 404,
                Message = "This Movie is not found"
            };

        var checkGenre = await unitOfWork.GenreRepository.GetByIdAsync(dto.GenreId);
        if (checkGenre is null)
            return new Response<MovieResultDto>()
            {
                StatusCode = 404,
                Message = "This Genre is not found"
            };

        var checkDirector = await unitOfWork.GenreRepository.GetByIdAsync(dto.GenreId);
        if (checkDirector is null)
            return new Response<MovieResultDto>()
            {
                StatusCode = 404,
                Message = "Director is not found"
            };

        var mapped = mapper.Map(dto, checkMovie);
        unitOfWork.MovieRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<MovieResultDto>(mapped);

        return new Response<MovieResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkMovie = await unitOfWork.MovieRepository.GetByIdAsync(id);
        if (checkMovie is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This Movie is not found"
            };

        unitOfWork.MovieRepository.Delete(checkMovie);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<MovieResultDto>> GetByIdAsync(long id)
    {
        var checkMovie = await unitOfWork.MovieRepository.GetByIdAsync(id);
        if (checkMovie is null)
            return new Response<MovieResultDto>()
            {
                StatusCode = 404,
                Message = "This Movie is not found"
            };

        var result = mapper.Map<MovieResultDto>(checkMovie);

        return new Response<MovieResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<MovieResultDto>> GetAll()
    {
        var checkMovies = unitOfWork.MovieRepository.GetAll().AsEnumerable();

        List<MovieResultDto> result = new();
        foreach (var movie in checkMovies)
            result.Add(mapper.Map<MovieResultDto>(movie));

        return new Response<IEnumerable<MovieResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
