using Microsoft.EntityFrameworkCore;
using PeruStar.API.Follower.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.Follower.Persistence.Repositories;

public class FollowerRepository: BaseRepository, IFollowerRepository
{
    public FollowerRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Follower>> ListAsync()
    {
        return await _context.Followers.ToListAsync();
    }

    public async Task<IEnumerable<Domain.Models.Follower>> ListByHobbyistIdAsync(long hobbyistId)
    {
        return await _context.Followers
            .Where(p => p.HobbyistId == hobbyistId)
            .Include(p => p.Hobbyist)
            .Include(p => p.Artist)
            .ToListAsync();
    }

    public async Task<IEnumerable<Domain.Models.Follower>> ListByArtistIdAsync(long artistId)
    {
        return await _context.Followers
            .Where(p => p.ArtistId == artistId)
            .Include(p => p.Hobbyist)
            .Include(p => p.Artist)
            .ToListAsync();
    }

    public async Task<Domain.Models.Follower> FindByHobbyistIdAndArtistId(long hobbyistId, long artistId)
    {
        return (await _context.Followers
            .Where(p => p.HobbyistId == hobbyistId && p.ArtistId == artistId)
            .Include(p => p.Hobbyist)
            .Include(p => p.Artist)
            .FirstOrDefaultAsync())!;
    }

    public async Task AddAsync(Domain.Models.Follower follower)
    {
        await _context.Followers.AddAsync(follower);
    }

    public void Remove(Domain.Models.Follower follower)
    {
        _context.Followers.Remove(follower);
    }

    public async Task AssignFollower(long hobbyistId, long artistId)
    {
        Domain.Models.Follower follower = await FindByHobbyistIdAndArtistId(hobbyistId, artistId);
        if (follower.Equals(null))
        {
            follower = new Domain.Models.Follower { HobbyistId = hobbyistId, ArtistId = artistId };
            await AddAsync(follower);
        }
    }

    public async Task UnassignFollower(long hobbyistId, long artistId)
    {
        Domain.Models.Follower follower = await FindByHobbyistIdAndArtistId(hobbyistId, artistId);
        if (follower.Equals(null))
            Remove(follower!);
    }

    public async Task<int> CountFollower(long artistId)
    {
        return await _context.Followers
            .Where(pt => pt.ArtistId == artistId)
            .Include(pt => pt.Artist)
            .Include(pt => pt.Hobbyist)
            .CountAsync();
    }
}