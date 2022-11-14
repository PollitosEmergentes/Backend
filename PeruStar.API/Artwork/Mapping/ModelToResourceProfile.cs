using AutoMapper;
using PeruStar.API.Artwork.Resources;

namespace PeruStar.API.Artwork.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Artwork, ArtworkResource>();
    }
}