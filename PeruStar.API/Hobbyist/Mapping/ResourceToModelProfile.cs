using AutoMapper;
using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Hobbyist.Resources;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Hobbyist.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveHobbyistResource, HobbyistResource>();
        CreateMap<SaveClaimTicketResource, ClaimTicket>();
    }
}