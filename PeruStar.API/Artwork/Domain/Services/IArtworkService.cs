using PeruStar.API.Artwork.Domain.Services.Communication;

namespace PeruStar.API.Artwork.Domain.Services;

public interface IArtworkService
{
    Task<ArtworkResponse> SaveAsync(long artistId, Models.Artwork artwork);
    Task<ArtworkResponse> UpdateAsync(long id, long artistId, Models.Artwork artwork);
    Task<ArtworkResponse> DeleteAsync(long id, long artistId);
    Task<bool> IsSameTitle(string title, long artistId);
}