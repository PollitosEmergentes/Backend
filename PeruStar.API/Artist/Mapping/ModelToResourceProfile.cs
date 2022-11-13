using AutoMapper;
using PeruStar.API.Artist.Resource;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Artist.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Artist, ArtistResource>();
    }

}