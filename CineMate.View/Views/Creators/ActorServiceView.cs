using CineMate.Service.DTOs;
using CineMate.Services.Creators;
using CineMate.View.IViews;
using CineMate.View.Views.Commons;

namespace CineMate.View.Views.Creators;

public class ActorServiceView : ServiceView<ActorService, ActorCreationDto, ActorUpdateDto, ActorResultDto>, IActorServiceView
{
    public ActorServiceView(ActorService actorService) : base(actorService)
    {
    }
}