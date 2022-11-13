using AutoMapper;
using PeruStar.API.Artwork.Resources;

namespace PeruStar.API.Artwork.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveArtworkResource, Domain.Models.Artwork>();
    }
}