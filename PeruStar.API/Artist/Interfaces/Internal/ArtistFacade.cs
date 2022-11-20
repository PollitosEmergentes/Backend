using PeruStar.API.Artist.Domain.Services.Communication;

namespace PeruStar.API.Artist.Interfaces.Internal;

public interface IArtistFacade
{
    Task<IEnumerable<Artist.Domain.Models.Artist>> ListAsync();
    Task<IEnumerable<Artist.Domain.Models.Artist>> ListByHobbyistIdAsync(int hobbyistId);
    Task<ArtistResponse> GetByIdAsync(long id);
}