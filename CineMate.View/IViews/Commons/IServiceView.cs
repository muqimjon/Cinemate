namespace CineMate.View.IViews.Commons;

public interface IServiceView
{
    Task CreateAsync();
    Task UpdateAsync();
    Task DeleteAsync();
    Task GetByIdAsync();
    void GetAll();
}
