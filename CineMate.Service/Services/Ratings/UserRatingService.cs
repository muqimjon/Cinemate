using AutoMapper;
using CineMate.Data.IRepositories.Commons;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;
using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces;
using CineMate.Service.Mappers;

namespace CineMate.Services.Ratings;

public class UserRatingService : IUserRatingService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public UserRatingService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<UserRatingResultDto>> CreateAsync(UserRatingCreationDto dto)
    {
        var checkUser = await unitOfWork.UserRepository.GetByIdAsync(dto.UserId);
        if(checkUser is null)
            return new Response<UserRatingResultDto>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var checkMovie = await unitOfWork.MovieRepository.GetByIdAsync(dto.MovieId);
        if (checkMovie is null)
            return new Response<UserRatingResultDto>()
            {
                StatusCode = 404,
                Message = "This Movie is not found"
            };

        dto.Rating = dto.Rating < 0 ? 0 : dto.Rating > 10 ? 10 : dto.Rating;

        var all = unitOfWork.UserRatingRepository.GetByMovieId(checkMovie.Id);
        var sum = all.Sum(x => x.Rating) + dto.Rating;
        var count = all.Count() + 1;
        checkMovie.Rating = Math.Round((decimal)sum/count, 2);
        unitOfWork.MovieRepository.Update(checkMovie);

        var mapped = mapper.Map<UserRating>(dto);
        await unitOfWork.UserRatingRepository.CreateAsync(mapped);

        await unitOfWork.SaveAsync();

        var result = mapper.Map<UserRatingResultDto>(mapped);

        return new Response<UserRatingResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<UserRatingResultDto>> UpdateAsync(UserRatingUpdateDto dto)
    {
        var checkUserRating = await unitOfWork.UserRatingRepository.GetByIdAsync(dto.Id);
        if (checkUserRating is null)
            return new Response<UserRatingResultDto>()
            {
                StatusCode = 404,
                Message = "This UserRating is not found"
            };

        var mapped = mapper.Map(dto, checkUserRating);
        unitOfWork.UserRatingRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<UserRatingResultDto>(mapped);

        return new Response<UserRatingResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkUserRating = await unitOfWork.UserRatingRepository.GetByIdAsync(id);
        if (checkUserRating is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This UserRating is not found"
            };

        unitOfWork.UserRatingRepository.Delete(checkUserRating);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<UserRatingResultDto>> GetByIdAsync(long id)
    {
        var checkUserRating = await unitOfWork.UserRatingRepository.GetByIdAsync(id);
        if (checkUserRating is null)
            return new Response<UserRatingResultDto>()
            {
                StatusCode = 404,
                Message = "This UserRating is not found"
            };

        var result = mapper.Map<UserRatingResultDto>(checkUserRating);

        return new Response<UserRatingResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<UserRatingResultDto>> GetAll()
    {
        var checkUserRating = unitOfWork.UserRatingRepository.GetAll().AsEnumerable();

        List<UserRatingResultDto> result = new();
        foreach (var UserRating in checkUserRating)
            result.Add(mapper.Map<UserRatingResultDto>(UserRating));

        return new Response<IEnumerable<UserRatingResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
