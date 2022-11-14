using AutoMapper;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Hobbyist.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Hobbyist, HobbyistResource>();
    }
    
}