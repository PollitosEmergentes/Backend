using AutoMapper;
using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Artwork.Domain.Models;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.Event.Domain.Models;
using PeruStar.API.Follower.Resources;
using PeruStar.API.Hobbyist.Resources;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.PeruStar.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
       CreateMap<SavePersonResource, PersonResource>();
    }
}