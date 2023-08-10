using AutoMapper;
using CineMate.Data.IRepositories.Commons;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;
using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces;
using CineMate.Service.Mappers;

namespace CineMate.Service.Services.Movies;

public class GenreService : IGenreService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public GenreService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<GenreResultDto>> CreateAsync(GenreCreationDto dto)
    {
        var mapped = mapper.Map<Genre>(dto);
        await unitOfWork.GenreRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<GenreResultDto>(mapped);

        return new Response<GenreResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<GenreResultDto>> UpdateAsync(GenreUpdateDto dto)
    {
        var checkGenre = await unitOfWork.GenreRepository.GetByIdAsync(dto.Id);
        if (checkGenre is null)
            return new Response<GenreResultDto>()
            {
                StatusCode = 404,
                Message = "This Genre is not found"
            };

        var mapped = mapper.Map(dto, checkGenre);
        unitOfWork.GenreRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<GenreResultDto>(mapped);

        return new Response<GenreResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkGenre = await unitOfWork.GenreRepository.GetByIdAsync(id);
        if (checkGenre is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This Genre is not found"
            };

        unitOfWork.GenreRepository.Delete(checkGenre);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<GenreResultDto>> GetByIdAsync(long id)
    {
        var checkGenre = await unitOfWork.GenreRepository.GetByIdAsync(id);
        if (checkGenre is null)
            return new Response<GenreResultDto>()
            {
                StatusCode = 404,
                Message = "This Genre is not found"
            };

        var result = mapper.Map<GenreResultDto>(checkGenre);

        return new Response<GenreResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<GenreResultDto>> GetAll()
    {
        var checkProductCategories = unitOfWork.GenreRepository.GetAll().AsEnumerable();

        List<GenreResultDto> result = new();
        foreach (var Genre in checkProductCategories)
            result.Add(mapper.Map<GenreResultDto>(Genre));

        return new Response<IEnumerable<GenreResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
