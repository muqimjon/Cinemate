using CineMate.Domain.Enums;
using CineMate.Service.DTOs;
using CineMate.View.IViews.Commons;

namespace CineMate.View.Views.Commons;

public class MainView
{
    private readonly IUnitOfView unitOfView = new UnitOfView();

    private UserResultDto user = new();

    public async Task Sign()
    {
        Console.WriteLine("---------- Main ----------\n" +
            "1. SignIn\n" +
            "2. SignUp\n" +
            "3. ResetPassword\n" +
            "0. Exit");

        var menu = int.Parse(Console.ReadLine()!);
        switch (menu)
        {
            case 1: user = await unitOfView.UserServiceView.SignIn(); break;
            case 2: user = await unitOfView.UserServiceView.SignUp(); break;
            case 3: user = await unitOfView.UserServiceView.ResetPasswordAsync(); break;
            case 0: return;
        }

        if (user is not null)
            if (user.Role.Equals(UserRole.User))
                await UserMenu(user);
            else
                await AdminMenu(user);
        await Sign();
    }

    private async Task AdminMenu(UserResultDto user)
    {
        Console.WriteLine("---------- Admin ----------\n" +
            "1. Users\n" +
            "2. Genres\n" +
            "3. Movies\n" +
            "4. Directors\n" +
            "5. Actors\n" +
            "6. Movie-Actor\n" +
            "7. Addresses\n" +
            "8. UserRatings\n" +
            "9. ChangeUserRole\n" +
            "0. Exit");

        var menu = int.Parse(Console.ReadLine()!);
        switch (menu)
        {
            case 1: await Crud(unitOfView.UserServiceView); break;
            case 2: await Crud(unitOfView.GenreServiceView); break;
            case 3: await Crud(unitOfView.MovieServiceView); break;
            case 4: await Crud(unitOfView.DirectorServiceView); break;
            case 5: await Crud(unitOfView.ActorServiceView); break;
            case 6: await Crud(unitOfView.MovieActorServiceView); break;
            case 7: await Crud(unitOfView.AddressServiceView); break;
            case 8: await Crud(unitOfView.UserRatingServiceView); break;
            case 9: await unitOfView.UserServiceView.ChangeUserRoleAsync(user.Role); break;
            case 0: return;
        }
        await AdminMenu(user);
    }

    private async Task Crud<T>(T service) where T : IServiceView
    {
        Console.WriteLine($"---------- Menu ----------\n" +
                          "1. Create\n" +
                          "2. Update\n" +
                          "3. Delete\n" +
                          "4. GetById\n" +
                          "5. GetAll\n" +
                          "0. Back");
        var menu = int.Parse(Console.ReadLine()!);
        switch(menu)
        {
            case 1: await service.CreateAsync(); break;
            case 2: await service.UpdateAsync(); break;
            case 3: await service.DeleteAsync(); break;
            case 4: await service.GetByIdAsync(); break;
            case 5: service.GetAll(); break;
            case 0: return;
        }
        await Crud(service);
    }


    private async Task UserMenu(UserResultDto user)
    {
        user = default!;
        Console.WriteLine("---------- User ----------\n" +
            "1. Top10\n" +
            "2. AllFilms\n" +
            "3. ByGenre\n" +
            "4. MyInfo\n" +
            "5. EditInfo\n" +
            "6. AddRating\n" +
            "0. Back");

        var menu = int.Parse(Console.ReadLine()!);
        switch (menu)
        {
            case 1: unitOfView.MovieServiceView.Top10(); break;
            case 2: unitOfView.MovieServiceView.GetAll(); break;
            case 3: await unitOfView.GenreServiceView.GetMovie(); break;
            case 4: unitOfView.UserServiceView.GetInfo(user); break;
            case 5: 
                user = await unitOfView.UserServiceView.UpdateInfoAsync(user);
                if(user is null)
                {
                    await Sign();
                    return;
                }
                break;
            case 6: await unitOfView.UserRatingServiceView.CreateAsync(); break;
            case 0: return;
        }
        await UserMenu(user);
    }
}
