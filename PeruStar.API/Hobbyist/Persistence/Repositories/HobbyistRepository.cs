using Microsoft.EntityFrameworkCore;
using PeruStar.API.Hobbyist.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.Hobbyist.Persistence.Repositories;

public class HobbyistRepository : BaseRepository, IHobbyistRepository
{
    public HobbyistRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Domain.Models.Hobbyist>> ListAsync()
    {
        return await _context.Hobbyists.ToListAsync();
    }
    

    public async Task AddAsync(Domain.Models.Hobbyist hobbyist)
    {
        await _context.Hobbyists.AddAsync(hobbyist);
    }

    public async Task<Domain.Models.Hobbyist> FindById(long id)
    {
        return (await _context.Hobbyists.FindAsync(id))!;
    }

    public void Update(Domain.Models.Hobbyist hobbyist)
    {
        _context.Hobbyists.Update(hobbyist);
    }

    public void Remove(Domain.Models.Hobbyist hobbyist)
    {
        _context.Hobbyists.Remove(hobbyist);
    }
}