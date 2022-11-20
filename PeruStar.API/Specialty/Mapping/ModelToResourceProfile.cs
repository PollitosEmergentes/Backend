using AutoMapper;
using PeruStar.API.PeruStar.Resources;
using PeruStar.API.Specialty.Resources;

namespace PeruStar.API.Specialty.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Specialty, SpecialtyResource>();
    }
}