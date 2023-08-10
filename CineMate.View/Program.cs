// See https://aka.ms/new-console-template for more information
using CineMate.View.IViews.Commons;
using CineMate.View.Views.Commons;


/*IUnitOfWork unitOfWork = new UnitOfWork();
await unitOfWork.UserRepository.CreateAsync(new User()
{
    DateOfBirth = new DateTimeOffset(new DateTime(2006, 10, 13)).UtcDateTime,
    Email = "muqimjon.mr@Gmail.com",
    FirstName = "Muqimjon",
    LastName = "Mamadaliyev",
    Phone = "+998937349808",
});
await unitOfWork.SaveAsync();*/



IUnitOfView unitOfView = new UnitOfView();


await unitOfView.UserServiceView.CreateAsync();