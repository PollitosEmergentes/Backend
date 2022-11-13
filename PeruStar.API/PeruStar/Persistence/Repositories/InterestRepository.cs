using Microsoft.EntityFrameworkCore;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.PeruStar.Persistence.Repositories;

public class InterestRepository: BaseRepository, IInterestRepository
{
    public InterestRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Interest>> ListAsync()
    {
        return await _context.Interests.ToListAsync();
    }

    public async Task<IEnumerable<Interest>> ListByHobbyistIdAsync(long hobbyistId)
    {
        return await _context.Interests
            .Where(p => p.HobbyistId == hobbyistId)
            .Include(p => p.Hobbyist)
            .ToListAsync();
    }

    public async Task<Interest> FindByHobbyistIdAndSpecialtyId(long hobbyistId, long specialtyId)
    {
        return (await _context.Interests
            .Where(p => p.HobbyistId == hobbyistId && p.SpecialtyId == specialtyId)
            .Include(p => p.Hobbyist)
            .FirstOrDefaultAsync())!;
    }

    public async Task AddAsync(Interest interest)
    {
        await _context.Interests.AddAsync(interest);
    }

    public void Remove(Interest interest)
    {
        _context.Interests.Remove(interest);
    }

    public async Task AssignInterest(long hobbyistId, long specialtyId)
    {
        Interest hobbyistSpecialty = await FindByHobbyistIdAndSpecialtyId(hobbyistId, specialtyId);
        if (hobbyistSpecialty.Equals(null))
        {
            hobbyistSpecialty = new Interest { HobbyistId = hobbyistId, SpecialtyId = specialtyId };
            await AddAsync(hobbyistSpecialty);
        }
    }

    public async Task UnassignInterest(long hobbyistId, long specialtyId)
    {
        Interest interest = await FindByHobbyistIdAndSpecialtyId(hobbyistId, specialtyId);
        if (interest.Equals(null))
            Remove(interest!);
    }
}