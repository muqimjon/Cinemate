using CineMate.Domain.Enums;
using CineMate.Domain.Entities;
using CineMate.DataAccess.Constants;
using Microsoft.EntityFrameworkCore;
using CineMate.Domain.Entities.Movies;

namespace CineMate.Data.DbContexts;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseLazyLoadingProxies();
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


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region SEED DATA

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, FirstName = "Muqimjon", LastName = "Mamadaliyev", Email = "muqimjon@gmail.com", Password = "a", Phone = "+998937349808", DateOfBirth = new DateTimeOffset(new DateTime(1998, 07, 22)).UtcDateTime, Role = UserRole.SuperAdmin },
            new User { Id = 2, FirstName = "Iskandar", LastName = "Qodirov", Email = "abdurahmon@gmail.com", Password = "a", Phone = "+998972350120", DateOfBirth = new DateTimeOffset(new DateTime(2006, 10, 13)).UtcDateTime },
            new User { Id = 3, FirstName = "Madiyor", LastName = "Odilov", Email = "madiyor@gmail.com", Password = "a", Phone = "+998903638333", DateOfBirth = new DateTimeOffset(new DateTime(2005, 11, 04)).UtcDateTime },
            new User { Id = 4, FirstName = "Nodir", LastName = "Ollonazarov", Email = "nodir@gmail.com", Password = "a", Phone = "+998881813525", DateOfBirth = new DateTimeOffset(new DateTime(2004, 02, 20)).UtcDateTime },
            new User { Id = 5, FirstName = "Nurullo", LastName = "Nurmatov", Email = "nurullo@gmail.com", Password = "a", Phone = "+998330022816", DateOfBirth = new DateTimeOffset(new DateTime(2003, 08, 16)).UtcDateTime },
            new User { Id = 6, FirstName = "Ravshanbek", LastName = "Isroilov", Email = "ravshanbek@gmail.com", Password = "a", Phone = "+998902528196", DateOfBirth = new DateTimeOffset(new DateTime(2002, 08, 18)).UtcDateTime },
            new User { Id = 7, FirstName = "Avazbek", LastName = "Siddiqov", Email = "avazbek@gmail.com", Password = "a", Phone = "+998973340334", DateOfBirth = new DateTimeOffset(new DateTime(1988, 04, 07)).UtcDateTime },
            new User { Id = 8, FirstName = "Abdualim", LastName = "Normurodov", Email = "abdualim@gmail.com", Password = "a", Phone = "+998950642799", DateOfBirth = new DateTimeOffset(new DateTime(2001, 11, 28)).UtcDateTime });

        // Address seed data
        modelBuilder.Entity<Address>().HasData(
            new Address { Id = 1, Country = "Uzbekistan", CountryCode = "UZ" },
            new Address { Id = 2, Country = "United States", CountryCode = "US" },
            new Address { Id = 3, Country = "Russia", CountryCode = "RU" },
            new Address { Id = 4, Country = "United Kingdom", CountryCode = "UK" },
            new Address { Id = 5, Country = "Germany", CountryCode = "DE" },
            new Address { Id = 6, Country = "France", CountryCode = "FR" },
            new Address { Id = 7, Country = "China", CountryCode = "CN" },
            new Address { Id = 8, Country = "India", CountryCode = "IN" },
            new Address { Id = 9, Country = "Japan", CountryCode = "JP" },
            new Address { Id = 10, Country = "South Korea", CountryCode = "KR" }
        );

        // Actor seed data
        modelBuilder.Entity<Actor>().HasData(
            new Actor { Id = 1, FirstName = "John", LastName = "Doe" },
            new Actor { Id = 2, FirstName = "Jane", LastName = "Smith" },
            new Actor { Id = 3, FirstName = "Michael", LastName = "Johnson" },
            new Actor { Id = 4, FirstName = "Emily", LastName = "Williams" },
            new Actor { Id = 5, FirstName = "David", LastName = "Brown" },
            new Actor { Id = 6, FirstName = "Sophia", LastName = "Jones" },
            new Actor { Id = 7, FirstName = "Robert", LastName = "Miller" },
            new Actor { Id = 8, FirstName = "Olivia", LastName = "Davis" },
            new Actor { Id = 9, FirstName = "William", LastName = "Garcia" },
            new Actor { Id = 10, FirstName = "Ava", LastName = "Rodriguez" },
            new Actor { Id = 11, FirstName = "Ethan", LastName = "Martinez" },
            new Actor { Id = 12, FirstName = "Mia", LastName = "Hernandez" },
            new Actor { Id = 13, FirstName = "Daniel", LastName = "Lopez" },
            new Actor { Id = 14, FirstName = "Emma", LastName = "Gonzalez" },
            new Actor { Id = 15, FirstName = "Alexander", LastName = "Perez" }
        );

        // Director seed data
        modelBuilder.Entity<Director>().HasData(
            new Director { Id = 1, FirstName = "Christopher", LastName = "Nolan" },
            new Director { Id = 2, FirstName = "Steven", LastName = "Spielberg" },
            new Director { Id = 3, FirstName = "Quentin", LastName = "Tarantino" },
            new Director { Id = 4, FirstName = "Greta", LastName = "Gerwig" },
            new Director { Id = 5, FirstName = "Martin", LastName = "Scorsese" },
            new Director { Id = 6, FirstName = "Ava", LastName = "DuVernay" },
            new Director { Id = 7, FirstName = "Denis", LastName = "Villeneuve" },
            new Director { Id = 8, FirstName = "Kathryn", LastName = "Bigelow" },
            new Director { Id = 9, FirstName = "Taika", LastName = "Waititi" },
            new Director { Id = 10, FirstName = "Sofia", LastName = "Coppola" }
        );

        // Genre seed data
        modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "Action" },
            new Genre { Id = 2, Name = "Drama" },
            new Genre { Id = 3, Name = "Comedy" },
            new Genre { Id = 4, Name = "Science Fiction" },
            new Genre { Id = 5, Name = "Adventure" },
            new Genre { Id = 6, Name = "Horror" },
            new Genre { Id = 7, Name = "Fantasy" },
            new Genre { Id = 8, Name = "Romance" },
            new Genre { Id = 9, Name = "Thriller" },
            new Genre { Id = 10, Name = "Animation" }
        );

        // Movie seed data
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Rating = 4.8m, ReleaseDate = new DateTimeOffset(new DateTime(2023, 3, 10)).UtcDateTime, Title = "Inception", GenreId = 4, DirectorId = 1, AddressId = 1 },
            new Movie { Id = 2, Rating = 4.5m, ReleaseDate = new DateTimeOffset(new DateTime(2022, 7, 20)).UtcDateTime, Title = "The Shawshank Redemption", GenreId = 2, DirectorId = 2, AddressId = 2 },
            new Movie { Id = 3, Rating = 8.5m, ReleaseDate = new DateTimeOffset(new DateTime(2022, 7, 15)).UtcDateTime, Title = "Adventure Awaits", GenreId = 1, DirectorId = 1, AddressId = 1 },
            new Movie { Id = 4, Rating = 4.7m, ReleaseDate = new DateTimeOffset(new DateTime(2021, 5, 15)).UtcDateTime, Title = "Pulp Fiction", GenreId = 9, DirectorId = 3, AddressId = 3 },
            new Movie { Id = 5, Rating = 4.6m, ReleaseDate = new DateTimeOffset(new DateTime(2020, 9, 8)).UtcDateTime, Title = "The Great Gatsby", GenreId = 8, DirectorId = 4, AddressId = 4 },
            new Movie { Id = 6, Rating = 4.3m, ReleaseDate = new DateTimeOffset(new DateTime(2019, 2, 5)).UtcDateTime, Title = "The Irishman", GenreId = 2, DirectorId = 5, AddressId = 5 }
        );

        // UserRating seed data
        modelBuilder.Entity<UserRating>().HasData(
            new UserRating { Id = 1, Rating = 5, Comment = "Amazing movie!", UserId = 1, MovieId = 1 },
            new UserRating { Id = 2, Rating = 4, Comment = "Really enjoyed it.", UserId = 2, MovieId = 2 },
            new UserRating { Id = 3, Rating = 4, Comment = "Good story.", UserId = 3, MovieId = 4 },
            new UserRating { Id = 4, Rating = 5, Comment = "Impressive acting.", UserId = 4, MovieId = 1 },
            new UserRating { Id = 5, Rating = 3, Comment = "Not bad.", UserId = 5, MovieId = 5 },
            new UserRating { Id = 6, Rating = 4, Comment = "Entertaining!", UserId = 6, MovieId = 6 },
            new UserRating { Id = 7, Rating = 4, Comment = "A true masterpiece.", UserId = 7, MovieId = 5 },
            new UserRating { Id = 8, Rating = 5, Comment = "Outstanding.", UserId = 8, MovieId = 4 },
            new UserRating { Id = 9, Rating = 4, Comment = "Enjoyed the movie", UserId = 1, MovieId = 3 }
        );

        modelBuilder.Entity<MovieActor>().HasData(
            new MovieActor { Id = 1, MovieId = 1, ActorId = 1 },
            new MovieActor { Id = 2, MovieId = 1, ActorId = 2 },
            new MovieActor { Id = 3, MovieId = 1, ActorId = 3 },
            new MovieActor { Id = 4, MovieId = 2, ActorId = 2 },
            new MovieActor { Id = 5, MovieId = 2, ActorId = 4 },
            new MovieActor { Id = 6, MovieId = 2, ActorId = 6 },
            new MovieActor { Id = 7, MovieId = 3, ActorId = 3 },
            new MovieActor { Id = 8, MovieId = 3, ActorId = 5 },
            new MovieActor { Id = 9, MovieId = 3, ActorId = 7 },
            new MovieActor { Id = 10, MovieId = 4, ActorId = 4 },
            new MovieActor { Id = 11, MovieId = 4, ActorId = 8 },
            new MovieActor { Id = 12, MovieId = 4, ActorId = 10 },
            new MovieActor { Id = 13, MovieId = 5, ActorId = 5 },
            new MovieActor { Id = 14, MovieId = 5, ActorId = 10 },
            new MovieActor { Id = 15, MovieId = 5, ActorId = 12 },
            new MovieActor { Id = 16, MovieId = 6, ActorId = 6 },
            new MovieActor { Id = 17, MovieId = 6, ActorId = 12 },
            new MovieActor { Id = 18, MovieId = 6, ActorId = 14 }
            );

        #endregion
    }
}
