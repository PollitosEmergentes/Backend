using AutoMapper;
using PeruStar.API.Follower.Resources;

namespace PeruStar.API.Follower.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Domain.Models.Follower, FollowerResource>();
    }
}