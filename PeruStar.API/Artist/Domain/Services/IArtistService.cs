using PeruStar.API.Artist.Domain.Services.Communication;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.Artist.Domain.Services;

public interface IArtistService
{
    Task<IEnumerable<Artist.Domain.Models.Artist>> ListAsync();
    Task<IEnumerable<Artist.Domain.Models.Artist>> ListByHobbyistIdAsync(int hobbyistId);
    Task<ArtistResponse> GetByIdAsync(long id);
    Task<ArtistResponse> SaveAsync(Artist.Domain.Models.Artist artist);
    Task<ArtistResponse> UpdateAsync(long id, Artist.Domain.Models.Artist artist);
    Task<ArtistResponse> DeleteAsync(long id);
    Task<bool> IsSameBrandingName(string brandingName);
}