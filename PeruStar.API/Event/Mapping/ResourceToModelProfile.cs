using AutoMapper;
using PeruStar.API.Event.Domain.Models;
using PeruStar.API.Event.Resources;

namespace PeruStar.API.Event.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveEventResource, Domain.Models.Event>();
        CreateMap<SaveEventAssistanceResource, EventAssistance>();
    }
}