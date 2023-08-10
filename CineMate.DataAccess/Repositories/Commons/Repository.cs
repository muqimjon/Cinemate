using Microsoft.EntityFrameworkCore;
using CineMate.Data.DbContexts;
using CineMate.Data.IRepositories.Commons;
using CineMate.Domain;

namespace CineMate.Data.Repositories.Commons;

public class Repository<T> : IRepository<T> where T : Auditable
{
    private readonly DbSet<T> dbSet;

    public Repository(AppDbContext appDbContext)
    {
        dbSet = appDbContext.Set<T>();
    }

    public async Task CreateAsync(T entity)
    {
        await dbSet.AddAsync(entity);
    }

    public void Update(T entity)
    {
        dbSet.Entry(entity).State = EntityState.Modified;
    }

    public void Delete(T entity)
    {
        dbSet.Remove(entity);
    }

    public async Task<T> GetByIdAsync(long id)
        => await dbSet.FirstOrDefaultAsync(e => e.Id.Equals(id)) ?? default!;

    public IQueryable<T> GetAll()
        => dbSet.AsNoTracking();
}
