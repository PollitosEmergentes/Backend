using AutoMapper;
using PeruStar.API.Artwork.Domain.Models;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Artwork.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveArtworkResource, Domain.Models.Artwork>();
        CreateMap<SaveFavoriteArtworkResource, FavoriteArtwork>();
    }
}