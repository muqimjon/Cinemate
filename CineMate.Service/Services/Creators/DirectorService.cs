using AutoMapper;
using CineMate.Service.DTOs;
using CineMate.Domain.Entities;
using CineMate.Service.Helpers;
using CineMate.Service.Mappers;
using CineMate.Data.Repositories.Commons;
using CineMate.Data.IRepositories.Commons;
using CineMate.Service.Interfaces.Creators;

namespace CineMate.Services.Creators;

public class DirectorService : IDirectorService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public DirectorService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<DirectorResultDto>> CreateAsync(DirectorCreationDto dto)
    {
        var mapped = mapper.Map<Director>(dto);
        await unitOfWork.DirectorRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<DirectorResultDto>(mapped);

        return new Response<DirectorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<DirectorResultDto>> UpdateAsync(DirectorUpdateDto dto)
    {
        var checkDirector = await unitOfWork.DirectorRepository.GetByIdAsync(dto.Id);
        if (checkDirector is null)
            return new Response<DirectorResultDto>()
            {
                StatusCode = 404,
                Message = "This Director is not found"
            };

        var mapped = mapper.Map(dto, checkDirector);
        unitOfWork.DirectorRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<DirectorResultDto>(mapped);

        return new Response<DirectorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkDirector = await unitOfWork.DirectorRepository.GetByIdAsync(id);
        if (checkDirector is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This Director is not found"
            };

        unitOfWork.DirectorRepository.Delete(checkDirector);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<DirectorResultDto>> GetByIdAsync(long id)
    {
        var checkDirector = await unitOfWork.DirectorRepository.GetByIdAsync(id);
        if (checkDirector is null)
            return new Response<DirectorResultDto>()
            {
                StatusCode = 404,
                Message = "This Director is not found"
            };

        var result = mapper.Map<DirectorResultDto>(checkDirector);

        return new Response<DirectorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<DirectorResultDto>> GetAll()
    {
        var checkDirector = unitOfWork.DirectorRepository.GetAll();

        List<DirectorResultDto> result = new();
        foreach (var Director in checkDirector)
            result.Add(mapper.Map<DirectorResultDto>(Director));

        return new Response<IEnumerable<DirectorResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}