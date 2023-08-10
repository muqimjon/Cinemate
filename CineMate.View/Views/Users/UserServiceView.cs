using CineMate.Service.DTOs;
using CineMate.Service.Services.Users;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;
using System.Reflection;

namespace CineMate.View.Views;

public class UserServiceView : ServiceView<UserService, UserCreationDto, UserUpdateDto, UserResultDto>, IUserServiceView
{
    private readonly UserService userService;
    public UserServiceView(UserService userService) : base(userService)
    {
        this.userService = userService;
    }

    public async Task GetByEmail()
    {
        Console.Write("Email: ");
        var email = Console.ReadLine();
        var result = await userService.GetByEmailAsync(email!);
        if(result.StatusCode != 200)
        {
            Console.WriteLine(result.Message);
            return;
        }

        var dto = result.Data;
        PropertyInfo[] properties = typeof(UserResultDto).GetProperties();

        foreach (var property in properties)
            Console.Write($"{property.Name}: {property.GetValue(dto)} | ");
        Console.WriteLine();
    }

    public async Task GetByPhone()
    {
        Console.Write("Phone: ");
        var phone = Console.ReadLine();
        var result = await userService.GetByPhoneAsync(phone!);
        if (result.StatusCode != 200)
        {
            Console.WriteLine(result.Message);
            return;
        }

        var dto = result.Data;
        PropertyInfo[] properties = typeof(UserResultDto).GetProperties();

        foreach (var property in properties)
            Console.Write($"{property.Name}: {property.GetValue(dto)} | ");
        Console.WriteLine();
    }
}
