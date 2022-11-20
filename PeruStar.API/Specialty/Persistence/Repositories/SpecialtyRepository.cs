using Microsoft.EntityFrameworkCore;
using PeruStar.API.Specialty.Domain.Repositories;
using PeruStar.API.Shared.Persistence.Contexts;
using PeruStar.API.Shared.Persistence.Repositories;

namespace PeruStar.API.Specialty.Persistence.Repositories;

    public class SpecialtyRepository : BaseRepository, ISpecialtyRepository
    {
        public SpecialtyRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Domain.Models.Specialty>> ListAsync()
        {
            return await _context.Specialties.ToListAsync();
        }

        public async Task AddAsync(Domain.Models.Specialty specialty)
        {
            await _context.Specialties.AddAsync(specialty);
        }

        public async Task<Domain.Models.Specialty> FindById(long id)
        {
            return (await _context.Specialties.FindAsync(id))!;
        }

        public void Update(Domain.Models.Specialty specialty)
        {
            _context.Specialties.Update(specialty);
        }

        public void Remove(Domain.Models.Specialty specialty)
        {
            _context.Specialties.Remove(specialty);
        }
    }

