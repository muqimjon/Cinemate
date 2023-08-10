using AutoMapper;
using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Mappers;
using CineMate.Data.Repositories.Commons;
using CineMate.Data.IRepositories.Commons;
using CineMate.Service.Interfaces.Addresses;
using CineMate.Domain.Entities;

namespace CineMate.Services.Addresses;

public class AddressService : IAddressService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public AddressService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<AddressResultDto>> CreateAsync(AddressCreationDto dto)
    {
        var mapped = mapper.Map<Address>(dto);
        await unitOfWork.AddressRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<AddressResultDto>(mapped);

        return new Response<AddressResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<AddressResultDto>> UpdateAsync(AddressUpdateDto dto)
    {
        var checkAddress = await unitOfWork.AddressRepository.GetByIdAsync(dto.Id);
        if (checkAddress is null)
            return new Response<AddressResultDto>()
            {
                StatusCode = 404,
                Message = "This Address is not found"
            };

        var mapped = mapper.Map(dto, checkAddress);
        unitOfWork.AddressRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<AddressResultDto>(mapped);

        return new Response<AddressResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkAddress = await unitOfWork.AddressRepository.GetByIdAsync(id);
        if (checkAddress is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This Address is not found"
            };

        unitOfWork.AddressRepository.Delete(checkAddress);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<AddressResultDto>> GetByIdAsync(long id)
    {
        var checkAddress = await unitOfWork.AddressRepository.GetByIdAsync(id);
        if (checkAddress is null)
            return new Response<AddressResultDto>()
            {
                StatusCode = 404,
                Message = "This Address is not found"
            };

        var result = mapper.Map<AddressResultDto>(checkAddress);

        return new Response<AddressResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<AddressResultDto>> GetAll()
    {
        var checkAddress = unitOfWork.AddressRepository.GetAll();

        List<AddressResultDto> result = new();
        foreach (var Address in checkAddress)
            result.Add(mapper.Map<AddressResultDto>(Address));

        return new Response<IEnumerable<AddressResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
