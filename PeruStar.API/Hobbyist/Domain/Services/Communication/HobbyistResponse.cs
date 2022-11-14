using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Hobbyist.Domain.Services.Communication;

public class HobbyistResponse : BaseResponse<Models.Hobbyist>
{
    public HobbyistResponse(Models.Hobbyist resource) : base(resource)
    {
    }

    public HobbyistResponse(string message) : base(message)
    {
    }
}