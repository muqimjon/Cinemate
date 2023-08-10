using CineMate.Service.Interfaces.Commons;
using CineMate.View.IViews.Commons;
using System.Reflection;

namespace CineMate.View.Views.Commons;

public class ServiceView<TService, TCreation, TUpdate, TResult> : IServiceView
    where TCreation : class, new()
    where TUpdate : class, new()
    where TResult : class, new()
    where TService : IServiceInterface<TCreation, TUpdate, TResult>, new()
{
    private readonly IServiceInterface<TCreation, TUpdate, TResult> service;

    public ServiceView(TService service)
    {
        this.service = service;
    }

    public async Task CreateAsync()
    {
        TCreation dto = new();

        PropertyInfo[] properties = typeof(TCreation).GetProperties();
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

        var result = await service.CreateAsync(dto);
        Console.WriteLine(result.Message);
    }

    public async Task UpdateAsync()
    {
        var checkDto = await service.GetByIdAsync(long.Parse(Console.ReadLine()!));
        if (checkDto.StatusCode != 200)
        {
            Console.WriteLine("This Id is not found");
            return;
        }

        TResult oldDto = checkDto.Data;
        TUpdate dto = new();

        PropertyInfo[] old = typeof(TResult).GetProperties();
        PropertyInfo[] properties = typeof(TUpdate).GetProperties();
        int count = 0;

        foreach (var property in properties)
        {
            Console.Write($"{property.Name}: {old[count++].GetValue(oldDto)}");

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
        var result = await service.UpdateAsync(dto);
        Console.WriteLine(result.Message);
    }

    public async Task DeleteAsync()
    {
        Console.Write("ID: ");
        long id = long.Parse(Console.ReadLine()!);
        var checkId = await service.GetByIdAsync(id);
        if (checkId.StatusCode != 200)
        {
            Console.WriteLine(checkId.Message);
            return;
        }

        var result = await service.DeleteAsync(id);
        Console.WriteLine(result.Message);
    }

    public async Task GetByIdAsync()
    {
        Console.Write("ID: ");
        long id = long.Parse(Console.ReadLine()!);
        var result = await service.GetByIdAsync(id);
        if (result.StatusCode != 200)
        {
            Console.WriteLine(result.Message);
            return;
        }

        var dto = result.Data;
        PropertyInfo[] properties = typeof(TResult).GetProperties();

        foreach (var property in properties)
            Console.Write($"{property.Name}: {property.GetValue(dto)} | ");
    }

    public void GetAll()
    {
        var result = service.GetAll();

        if (result.StatusCode != 200)
        {
            Console.WriteLine(result.Message);
            return;
        }
        foreach (var dto in result.Data)
            {
                PropertyInfo[] properties = typeof(TResult).GetProperties();
                foreach (var property in properties)
                    Console.Write($"{property.Name}: {property.GetValue(dto)} | ");
                Console.WriteLine();
            }
    }
}
