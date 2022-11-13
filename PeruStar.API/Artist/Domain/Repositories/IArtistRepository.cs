namespace PeruStar.API.Artist.Domain.Repositories;

public interface IArtistRepository
{
    Task<IEnumerable<Models.Artist>> ListAsync();
    Task AddAsync(Models.Artist artist);
    Task<Models.Artist> FindById(long id);
    void Update(Models.Artist artist);
    void Remove(Models.Artist artist);
    Task<bool> IsSameBrandingName(string brandingName);
}