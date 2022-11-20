using AutoMapper;
using PeruStar.API.Artwork.Domain.Models;
using PeruStar.API.Artwork.Resources;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Artwork.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Artwork, ArtworkResource>();
        CreateMap<FavoriteArtwork, FavoriteArtworkResource>();
    }
}