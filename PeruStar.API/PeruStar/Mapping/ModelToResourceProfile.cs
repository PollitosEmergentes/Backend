using AutoMapper;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.Event.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.PeruStar.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<ClaimTicket, ClaimTicketResource>();
        CreateMap<FavoriteArtwork, FavoriteArtworkResource>();
        CreateMap<Person, PersonResource>();
        CreateMap<Specialty, SpecialtyResource>();
        CreateMap<Hobbyist, HobbyistResource>();
        CreateMap<Follower, FollowerResource>();
        CreateMap<Interest, InterestResource>();
    }
}