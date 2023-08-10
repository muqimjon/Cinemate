using AutoMapper;
using CineMate.Data.IRepositories.Commons;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;
using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces.Creators;
using CineMate.Service.Mappers;

namespace CineMate.Services.Creators;

public class ActorService : IActorService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public ActorService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<ActorResultDto>> CreateAsync(ActorCreationDto dto)
    {
        var mapped = mapper.Map<Actor>(dto);
        await unitOfWork.ActorRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<ActorResultDto>(mapped);

        return new Response<ActorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<ActorResultDto>> UpdateAsync(ActorUpdateDto dto)
    {
        var checkActor = await unitOfWork.ActorRepository.GetByIdAsync(dto.Id);
        if (checkActor is null)
            return new Response<ActorResultDto>()
            {
                StatusCode = 404,
                Message = "This Actor is not found"
            };

        var mapped = mapper.Map(dto, checkActor);
        unitOfWork.ActorRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<ActorResultDto>(mapped);

        return new Response<ActorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkActor = await unitOfWork.ActorRepository.GetByIdAsync(id);
        if (checkActor is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This Actor is not found"
            };

        unitOfWork.ActorRepository.Delete(checkActor);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<ActorResultDto>> GetByIdAsync(long id)
    {
        var checkActor = await unitOfWork.ActorRepository.GetByIdAsync(id);
        if (checkActor is null)
            return new Response<ActorResultDto>()
            {
                StatusCode = 404,
                Message = "This Actor is not found"
            };

        var result = mapper.Map<ActorResultDto>(checkActor);

        return new Response<ActorResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<ActorResultDto>> GetAll()
    {
        var checkActor = unitOfWork.ActorRepository.GetAll().AsEnumerable();

        List<ActorResultDto> result = new();
        foreach (var Actor in checkActor)
            result.Add(mapper.Map<ActorResultDto>(Actor));

        return new Response<IEnumerable<ActorResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
