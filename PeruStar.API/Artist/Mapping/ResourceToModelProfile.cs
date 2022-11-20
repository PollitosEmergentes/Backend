using AutoMapper;
using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Artist.Resource;
using PeruStar.API.Artist.Resources;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Artist.Mapping;

public class ResourceToModelProfile:Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveArtistResource, Domain.Models.Artist>();
        CreateMap<SaveInterestResource, Interest>();
    }
}