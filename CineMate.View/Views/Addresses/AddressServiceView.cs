using CineMate.Service.DTOs;
using CineMate.Services.Addresses;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;

namespace CineMate.View.Views;

public class AddressServiceView : ServiceView<AddressService, AddressCreationDto, AddressUpdateDto, AddressResultDto> ,IAddressServiceView
{
    public AddressServiceView(AddressService addressService) : base(addressService)
    {
    }
}
