using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Artist.Domain.Services.Communication;

public class ArtistResponse : BaseResponse<Models.Artist>
{
    public ArtistResponse(Models.Artist resource) : base(resource)
    {
    }

    public ArtistResponse(string message) : base(message)
    {
    }
}