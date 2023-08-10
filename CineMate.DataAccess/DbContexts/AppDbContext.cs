using CineMate.Domain.Enums;
using CineMate.Domain.Entities;
using CineMate.DataAccess.Constants;
using Microsoft.EntityFrameworkCore;

namespace CineMate.Data.DbContexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseNpgsql(Constant.STRING_CONNECTION);
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<UserRating> UserRatings { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Actor> Actors { get; set; }
    public DbSet<User> Users { get; set; }


    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //{
    //    #region FLUENT API
    //    #endregion

    //    #region FOREIGN KEYNI RUCHNOY BOG'LASH

    //    //base.OnModelCreating(modelBuilder);
    //    //modelBuilder.Entity<Product>()
    //    //    .HasOne(p => p.Category)
    //    //    .WithMany(c => c.Products)
    //    //    .HasForeignKey(p => p.CategoryId);

    //    //modelBuilder.Entity<Genre>()
    //    //    .HasMany(c => c.Products)
    //    //    .WithOne(p => p.Category)
    //    //    .HasForeignKey(c => c.CategoryId)
    //    //    .OnDelete(DeleteBehavior.Cascade);
    //    //#endregion

    //    #region SEED DATA

    //    //modelBuilder.Entity<Genre>().HasData(
    //    //    new Genre() { Id = 1, Name = "Pizzas", CreateAt = DateTime.UtcNow, UpdateAt = null },
    //    //    new Genre() { Id = 2, Name = "Souces", CreateAt = DateTime.UtcNow, UpdateAt = null });

    //    //modelBuilder.Entity<Movie>().HasData(
    //    //    new Movie() { Id = 1, Name = "Cheesburger", Description = "", Unit = Unit.pc, CategoryId = 1, Price = 24000, Quantity = 4, CreateAt = DateTime.UtcNow, UpdateAt = null },
    //    //    new Movie() { Id = 2, Name = "Coffee", Description = "", Unit = Unit.pc, CategoryId = 2, Price = 24000, Quantity = 4, CreateAt = DateTime.UtcNow, UpdateAt = null });
    //    #endregion
    //}
}
