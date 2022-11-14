using PeruStar.API.Artwork.Domain.Services.Communication;

namespace PeruStar.API.Artwork.Interfaces.Internal;

public interface IArtworkFacade
{
    Task<IEnumerable<Domain.Models.Artwork>> ListByArtistIdAsync(long id);
    Task<ArtworkResponse> FindByIdAndArtistIdAsync(long id, long artistId);
}