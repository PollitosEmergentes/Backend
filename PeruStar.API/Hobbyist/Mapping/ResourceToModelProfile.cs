using AutoMapper;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Hobbyist.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveHobbyistResource, Domain.Models.Hobbyist>();
    }
    
}