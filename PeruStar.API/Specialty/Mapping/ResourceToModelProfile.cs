using AutoMapper;
using PeruStar.API.PeruStar.Resources;
using PeruStar.API.Specialty.Resources;

namespace PeruStar.API.Specialty.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveSpecialtyResource, Domain.Models.Specialty>();
    }
}