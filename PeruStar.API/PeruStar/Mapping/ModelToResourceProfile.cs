using AutoMapper;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.PeruStar.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ClaimTicket, ClaimTicketResource>();
        CreateMap<Event, EventResource>();
        CreateMap<EventAssistance, EventAssistanceResource>();
        CreateMap<FavoriteArtwork, FavoriteArtworkResource>();
        CreateMap<Person, PersonResource>();
        CreateMap<Specialty, SpecialtyResource>();
        CreateMap<Hobbyist.Domain.Models.Hobbyist, HobbyistResource>();
        CreateMap<Follower, FollowerResource>();
        CreateMap<Interest, InterestResource>();
    }
}