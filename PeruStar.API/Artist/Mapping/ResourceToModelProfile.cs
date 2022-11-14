using AutoMapper;
using PeruStar.API.Artist.Resource;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Artist.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveArtistResource, Domain.Models.Artist>();
    }
}