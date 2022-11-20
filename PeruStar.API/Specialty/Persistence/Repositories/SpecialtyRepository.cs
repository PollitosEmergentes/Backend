using Microsoft.EntityFrameworkCore;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;
using PeruStar.API.Specialty.Domain.Repositories;

namespace PeruStar.API.Specialty.Persistence.Repositories
{
    public class SpecialtyRepository : BaseRepository, ISpecialtyRepository
    {
        public SpecialtyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Specialty.Domain.Models.Specialty>> ListAsync()
        {
            return await _context.Specialties.ToListAsync();
        }

        public async Task AddAsync(Specialty.Domain.Models.Specialty specialty)
        {
            await _context.Specialties.AddAsync(specialty);
        }

        public async Task<Specialty.Domain.Models.Specialty> FindById(long id)
        {
            return (await _context.Specialties.FindAsync(id))!;
        }

        public void Update(Specialty.Domain.Models.Specialty specialty)
        {
            _context.Specialties.Update(specialty);
        }

        public void Remove(Specialty.Domain.Models.Specialty specialty)
        {
            _context.Specialties.Remove(specialty);
        }
    }
}
