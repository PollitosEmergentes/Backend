using AutoMapper;
using PeruStar.API.Specialty.Resources;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Specialty.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveSpecialtyResource, Domain.Models.Specialty>();
    }
}
