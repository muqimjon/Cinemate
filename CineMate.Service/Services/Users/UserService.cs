using AutoMapper;
using CineMate.Data.IRepositories.Commons;
using CineMate.Data.Repositories.Commons;
using CineMate.Domain.Entities;
using CineMate.Service.DTOs;
using CineMate.Service.Helpers;
using CineMate.Service.Interfaces.Users;
using CineMate.Service.Mappers;

namespace CineMate.Service.Services.Users;

public class UserService : IUserService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;
    public UserService()
    {
        unitOfWork = new UnitOfWork();
        mapper = new Mapper(new MapperConfiguration(cf
            => cf.AddProfile<MappingProfile>()));
    }

    public async Task<Response<UserResultDto>> CreateAsync(UserCreationDto dto)
    {
        var check = await unitOfWork.UserRepository.GetByPhoneAsync(dto.Email);
        if (check is not null)
            return new Response<UserResultDto>()
            {
                StatusCode = 403,
                Message = "This User is already exist"
            };

        var mapped = mapper.Map<User>(dto);
        await unitOfWork.UserRepository.CreateAsync(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<UserResultDto>(mapped);

        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<UserResultDto>> UpdateAsync(UserUpdateDto dto)
    {
        var checkUser = await unitOfWork.UserRepository.GetByIdAsync(dto.Id);
        if (checkUser is null)
            return new Response<UserResultDto>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var mapped = mapper.Map(dto, checkUser);
        unitOfWork.UserRepository.Update(mapped);
        await unitOfWork.SaveAsync();
        var result = mapper.Map<UserResultDto>(mapped);

        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<bool>> DeleteAsync(long id)
    {
        var checkUser = await unitOfWork.UserRepository.GetByIdAsync(id);
        if (checkUser is null)
            return new Response<bool>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        unitOfWork.UserRepository.Delete(checkUser);
        await unitOfWork.SaveAsync();

        return new Response<bool>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = true
        };
    }

    public async Task<Response<UserResultDto>> GetByIdAsync(long id)
    {
        var checkUser = await unitOfWork.UserRepository.GetByIdAsync(id);
        if (checkUser is null)
            return new Response<UserResultDto>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var result = mapper.Map<UserResultDto>(checkUser);

        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public Response<IEnumerable<UserResultDto>> GetAll()
    {
        var checkUsers = unitOfWork.UserRepository.GetAll();

        List<UserResultDto> result = new();
        foreach (var user in checkUsers)
            result.Add(mapper.Map<UserResultDto>(user));

        return new Response<IEnumerable<UserResultDto>>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<UserResultDto>> GetByPhoneAsync(string phone)
    {
        var checkUser = await unitOfWork.UserRepository.GetByPhoneAsync(phone);
        if (checkUser is null)
            return new Response<UserResultDto>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var result = mapper.Map<UserResultDto>(checkUser);

        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }

    public async Task<Response<UserResultDto>> GetByEmailAsync(string email)
    {
        var checkUser = await unitOfWork.UserRepository.GetByEmailAsync(email);
        if (checkUser is null)
            return new Response<UserResultDto>()
            {
                StatusCode = 404,
                Message = "This User is not found"
            };

        var result = mapper.Map<UserResultDto>(checkUser);

        return new Response<UserResultDto>()
        {
            StatusCode = 200,
            Message = "Success",
            Data = result
        };
    }
}
