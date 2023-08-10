using AutoMapper;
using CineMate.Data.IRepositories.Commons;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities.Movies;
using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces;
using CineMate.Service.Mappers;

namespace CineMate.Service.Services.Movies;

public class MovieActorService : IMovieActorService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public MovieActorService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<MovieActorResultDto>> CreateAsync(MovieActorCreationDto dto)
    {
        var checkMovie = unitOfWork.MovieRepository.GetByIdAsync(dto.MovieId);
        if (checkMovie is null)
            return new Response<MovieActorResultDto>
            {
                StatusCode = 404,
                Message = "This Movie is not found"
            };

        var checkActor = unitOfWork.MovieRepository.GetByIdAsync(dto.ActorId);
        if (checkMovie is null)
            return new Response<MovieActorResultDto>
            {
                StatusCode = 404,
                Message = "This Actor is not found"
            };

        var mapped = mapper.Map<MovieActor>(dto);
        await unitOfWork.MovieActorRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<MovieActorResultDto>(mapped);

        return new Response<MovieActorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<MovieActorResultDto>> UpdateAsync(MovieActorUpdateDto dto)
    {
        var checkMovieActor = await unitOfWork.MovieActorRepository.GetByIdAsync(dto.Id);
        if (checkMovieActor is null)
            return new Response<MovieActorResultDto>()
            {
                StatusCode = 404,
                Message = "This MovieActor is not found"
            };

        var checkMovie = unitOfWork.MovieRepository.GetByIdAsync(dto.MovieId);
        if (checkMovie is null)
            return new Response<MovieActorResultDto>
            {
                StatusCode = 404,
                Message = "This Movie is not found"
            };

        var checkActor = unitOfWork.MovieRepository.GetByIdAsync(dto.ActorId);
        if (checkMovie is null)
            return new Response<MovieActorResultDto>
            {
                StatusCode = 404,
                Message = "This Actor is not found"
            };

        var mapped = mapper.Map(dto, checkMovieActor);
        unitOfWork.MovieActorRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<MovieActorResultDto>(mapped);

        return new Response<MovieActorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkMovieActor = await unitOfWork.MovieActorRepository.GetByIdAsync(id);
        if (checkMovieActor is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This MovieActor is not found"
            };

        unitOfWork.MovieActorRepository.Delete(checkMovieActor);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<MovieActorResultDto>> GetByIdAsync(long id)
    {
        var checkMovieActor = await unitOfWork.MovieActorRepository.GetByIdAsync(id);
        if (checkMovieActor is null)
            return new Response<MovieActorResultDto>()
            {
                StatusCode = 404,
                Message = "This MovieActor is not found"
            };

        var result = mapper.Map<MovieActorResultDto>(checkMovieActor);

        return new Response<MovieActorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<MovieActorResultDto>> GetAll()
    {
        var checkProductCategories = unitOfWork.MovieActorRepository.GetAll().AsEnumerable();

        List<MovieActorResultDto> result = new();
        foreach (var MovieActor in checkProductCategories)
            result.Add(mapper.Map<MovieActorResultDto>(MovieActor));

        return new Response<IEnumerable<MovieActorResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}