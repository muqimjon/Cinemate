using CineMate.Service.DTOs;
using CineMate.Service.Interfaces.Commons;

namespace CineMate.Service.Interfaces.Addresses;

public interface IAddressService : IServiceInterface<AddressCreationDto, AddressUpdateDto, AddressResultDto>
{
}
