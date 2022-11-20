using AutoMapper;
using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Hobbyist.Resources;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Hobbyist.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Hobbyist, HobbyistResource>();
        CreateMap<ClaimTicket, ClaimTicketResource>();
    }
}