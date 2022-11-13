namespace PeruStar.API.Artwork.Domain.Repositories;

public interface IArtworkRepository
{
    Task<IEnumerable<Models.Artwork>> ListAsync();
    Task AddAsync(Models.Artwork artwork);
    Task<Models.Artwork> FindByIdAndArtistIdAsync(long id, long artistId);
    Task<IEnumerable<Models.Artwork>> ListByArtistIdAsync(long artistId);
    void Update(Models.Artwork artwork);
    void Remove(Models.Artwork artwork);
    Task<bool> IsSameTitle(string title, long artistId);
}