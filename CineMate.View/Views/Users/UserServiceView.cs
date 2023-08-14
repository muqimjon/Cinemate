using CineMate.Domain.Enums;
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

    public async Task<UserResultDto> SignIn()
    {
        if(!userService.GetAll().Data.Any())
        {
            Console.WriteLine("User table is empty");
            return default!;
        }

        Console.Write("Email: ");
        var checkUser = await userService.GetByEmailAsync(Console.ReadLine()!);
        if (checkUser.StatusCode != 200)
        {
            Console.WriteLine(checkUser.Message);
            return default!;
        }

        var dto = checkUser.Data;
        Console.Write("Password: ");
        if (dto.Password.Equals(Console.ReadLine()))
            return dto;

        Console.WriteLine("Invalid password");
        return default!;
    }

    public async Task<UserResultDto> SignUp()
    {
        UserCreationDto dto = new();
        PropertyInfo[] properties = typeof(UserCreationDto).GetProperties();

        foreach (var property in properties)
        {
            Console.Write(property.Name + ": ");

            if (property.PropertyType == typeof(long))
                property.SetValue(dto, long.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(int))
                property.SetValue(dto, int.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(string))
                property.SetValue(dto, Console.ReadLine());
            else if (property.PropertyType == typeof(decimal))
                property.SetValue(dto, decimal.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(double))
                property.SetValue(dto, double.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(DateTime))
            {
                Console.Write("(dd mm year): ");
                property.SetValue(dto, new DateTimeOffset(DateTime.Parse(Console.ReadLine()!)).UtcDateTime);
            }
            else if (property.PropertyType == typeof(bool))
            {
                Console.Write("(true/false): ");
                property.SetValue(dto, bool.Parse(Console.ReadLine()!));
            }
            else if (property.PropertyType.IsEnum)
            {
                var names = Enum.GetNames(property.PropertyType);
                long queue = 1;
                Console.WriteLine();
                foreach (var name in names)
                    Console.WriteLine($"\t{queue++}. {name}");

                if (int.TryParse(Console.ReadLine(), out int enumIndex) && enumIndex >= 0 && enumIndex < names.Length)
                    property.SetValue(dto, Enum.Parse(property.PropertyType, names[enumIndex]));
                else
                {
                    Console.WriteLine("Invalid enum value.");
                    property.SetValue(dto, Enum.Parse(property.PropertyType, names.LastOrDefault()!));
                }
            }
        }
        var result = await userService.CreateAsync(dto);
        Console.WriteLine(result.Message);

        return result.StatusCode is 200 ? result.Data : default!;
    }

    public async Task ChangeUserRoleAsync(UserRole role)
    {
        if(!role.Equals(UserRole.SuperAdmin))
        {
            Console.WriteLine("You do not have this right");
            return;
        }

        Console.Write("Id");
        var id = long.Parse(Console.ReadLine()!);

        var names = Enum.GetNames(typeof(UserRole));
        long queue = 1;
        Console.WriteLine();
        foreach (var name in names)
            Console.WriteLine($"\t{queue++}. {name}");

        Console.Write("Role: ");
        int enumIndex = int.Parse(Console.ReadLine()!);

        var result = await userService.ChangeUserRoleAsync(id, enumIndex);
        Console.WriteLine(result.Message);
    }

    public async Task<UserResultDto> ResetPasswordAsync()
    {
        Console.Write("Email: ");
        string email = Console.ReadLine()!;

        Console.Write("Phone: ");
        string phone = Console.ReadLine()!;

        Console.Write("NewPassword: ");
        string password = Console.ReadLine()!;

        var result = await userService.ResetPasswordAsync(email, phone, password);

        Console.WriteLine(result.Message);
        return result.Data;
    }

    public void GetInfo(UserResultDto dto)
    {
        PropertyInfo[] properties = typeof(UserResultDto).GetProperties();

        foreach (var property in properties)
            Console.Write($"{property.Name}: {property.GetValue(dto)} | ");
        Console.WriteLine();
    }

    public async Task<UserResultDto> UpdateInfoAsync(UserResultDto old)
    {
        var checkDto = await userService.GetByIdAsync(old.Id);
        if (checkDto.StatusCode != 200)
        {
            Console.WriteLine("This Id is not found");
            return default!;
        }

        UserUpdateDto dto = new();
        PropertyInfo[] properties = typeof(UserUpdateDto).GetProperties();
        PropertyInfo[] oldProperty = typeof(UserResultDto).GetProperties();

        foreach (var property in properties)
        {
            Console.Write($"{property.Name}: ");
            foreach (var item in oldProperty)
                if (item.Name.Equals(property.Name))
                    Console.WriteLine(item.GetValue(old));

            if (property.Name.Equals("Id"))
            {
                dto.Id = old.Id;
                continue;
            }
            
            Console.Write("New: ");

            if (property.PropertyType == typeof(long))
                property.SetValue(dto, long.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(int))
                property.SetValue(dto, int.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(string))
                property.SetValue(dto, Console.ReadLine());
            else if (property.PropertyType == typeof(decimal))
                property.SetValue(dto, decimal.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(double))
                property.SetValue(dto, double.Parse(Console.ReadLine()!));
            else if (property.PropertyType == typeof(DateTime))
                property.SetValue(dto, new DateTimeOffset(DateTime.Parse(Console.ReadLine()!)).UtcDateTime);
            else if (property.PropertyType.IsEnum)
            {
                var names = Enum.GetNames(property.PropertyType);
                long queue = 1;
                Console.WriteLine();
                foreach (var name in names)
                    Console.WriteLine($"\t{queue++}. {name}");

                if (int.TryParse(Console.ReadLine(), out int enumIndex) && enumIndex >= 0 && enumIndex < names.Length)
                    property.SetValue(dto, Enum.Parse(property.PropertyType, names[enumIndex]));
                else
                {
                    Console.WriteLine("Invalid enum value.");
                    property.SetValue(dto, Enum.Parse(property.PropertyType, names.LastOrDefault()!));
                }
            }
        }

        var result = await userService.UpdateAsync(dto);
        Console.WriteLine(result.Message);
        return result.Data;
    }
}
