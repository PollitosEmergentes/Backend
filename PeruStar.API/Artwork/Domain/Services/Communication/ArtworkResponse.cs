using PeruStar.API.Shared.Domain.Services.Communication;

namespace PeruStar.API.Artwork.Domain.Services.Communication;

public class ArtworkResponse : BaseResponse<Models.Artwork>
{
    public ArtworkResponse(Models.Artwork resource) : base(resource)
    {
    }

    public ArtworkResponse(string message) : base(message)
    {
    }
}