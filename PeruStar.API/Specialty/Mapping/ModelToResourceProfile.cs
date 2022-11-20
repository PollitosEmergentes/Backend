using AutoMapper;
using PeruStar.API.Specialty.Resources;
using PeruStar.API.PeruStar.Resources;

namespace PeruStar.API.Specialty.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Specialty, SpecialtyResource>();
    }

}
