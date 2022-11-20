using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Artist.Domain.Services.Communication;

public class InterestResponse: BaseResponse<Interest>
{
    public InterestResponse(Interest resource) : base(resource)
    {
    }

    public InterestResponse(string message) : base(message)
    {
    }
}