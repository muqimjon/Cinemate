using AutoMapper;
using CineMate.Domain.Entities;
using CineMate.Domain.Entities.Movies;
using CineMate.Service.DTOs;

namespace CineMate.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User
        CreateMap<User, UserResultDto>();
        CreateMap<UserUpdateDto, User>();
        CreateMap<UserCreationDto, User>();

        // Movie
        CreateMap<Movie, MovieResultDto>();
        CreateMap<MovieUpdateDto, Movie>();
        CreateMap<MovieCreationDto, Movie>();

        // Genre
        CreateMap<Genre, GenreResultDto>();
        CreateMap<GenreUpdateDto, Genre>();
        CreateMap<GenreCreationDto, Genre>();

        // Actor
        CreateMap<Actor, ActorResultDto>();
        CreateMap<ActorUpdateDto, Actor>();
        CreateMap<ActorCreationDto, Actor>();

        // Director
        CreateMap<Director, DirectorResultDto>();
        CreateMap<DirectorUpdateDto, Director>();
        CreateMap<DirectorCreationDto, Director>();

        // Address
        CreateMap<Address, AddressResultDto>();
        CreateMap<AddressUpdateDto, Address>();
        CreateMap<AddressCreationDto, Address>();

        // Movie
        CreateMap<Movie, MovieResultDto>();
        CreateMap<MovieUpdateDto, Movie>();
        CreateMap<MovieCreationDto, Movie>();

        // UserRating
        CreateMap<UserRating, UserRatingResultDto>();
        CreateMap<UserRatingUpdateDto, UserRating>();
        CreateMap<UserRatingCreationDto, UserRating>();

        // MovieActor
        CreateMap<MovieActor, MovieActorResultDto>();
        CreateMap<MovieActorUpdateDto, MovieActor>();
        CreateMap<MovieActorCreationDto, MovieActor>();
    }
}
