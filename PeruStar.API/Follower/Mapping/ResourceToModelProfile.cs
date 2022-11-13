using AutoMapper;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.PeruStar.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
       CreateMap<SaveFollowerResource, FollowerResource>();

    }
}