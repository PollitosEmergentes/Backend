using AutoMapper;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.PeruStar.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
       CreateMap<SaveClaimTicketResource, ClaimTicket>();
       CreateMap<SaveEventResource, Event>();
       CreateMap<SaveEventAssistanceResource, EventAssistance>();
       CreateMap<SaveFavoriteArtworkResource, FavoriteArtwork>();
       CreateMap<SavePersonResource, PersonResource>();
       CreateMap<SaveSpecialtyResource, Specialty>();
       CreateMap<SaveHobbyistResource, HobbyistResource>();
       CreateMap<SaveFollowerResource, FollowerResource>();
       CreateMap<SaveInterestResource, Interest>();

    }
}