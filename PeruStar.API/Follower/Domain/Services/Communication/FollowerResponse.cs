using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Follower.Domain.Services.Communication
{
    public class FollowerResponse: BaseResponse<Models.Follower>
    {
        public FollowerResponse(Models.Follower resource) : base(resource)
        {

        }
        public FollowerResponse(string message) : base(message)
        {

        }
    }
}
