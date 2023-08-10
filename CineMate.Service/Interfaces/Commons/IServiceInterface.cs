using CineMate.Service.Helpers;

namespace CineMate.Service.Interfaces.Commons;

public interface IServiceInterface<TCreate, TUpdate, TResult>
{
    Task<Response<TResult>> CreateAsync(TCreate dto);
    Task<Response<TResult>> UpdateAsync(TUpdate dto);
    Task<Response<bool>> DeleteAsync(long id);
    Task<Response<TResult>> GetByIdAsync(long id);
    Response<IEnumerable<TResult>> GetAll();
}
