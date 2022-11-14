using Microsoft.EntityFrameworkCore;
using PeruStar.API.Artist.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.Artist.Persistence.Repositories;

public class ArtistRepository : BaseRepository, IArtistRepository
{
    public ArtistRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Artist>> ListAsync()
    {
        return await _context.Artists.ToListAsync();
    }

    public async Task AddAsync(Domain.Models.Artist artist)
    {
        await _context.Artists.AddAsync(artist);
    }

    public async Task<Domain.Models.Artist> FindById(long id)
    {
        return (await _context.Artists.FindAsync(id))!;
    }

    public void Update(Domain.Models.Artist artist)
    {
        _context.Artists.Update(artist);
    }

    public void Remove(Domain.Models.Artist artist)
    {
        _context.Artists.Remove(artist);
    }

    public async Task<bool> IsSameBrandingName(string brandingName)
    {
        return await _context.Artists.AnyAsync(x => x.BrandName == brandingName);
    }
}