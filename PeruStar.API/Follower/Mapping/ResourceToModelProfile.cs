using AutoMapper;
using PeruStar.API.Follower.Resources;

namespace PeruStar.API.Follower.Mapping;

public class ResourceToModelProfile: Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveFollowerResource, FollowerResource>();
    }
}