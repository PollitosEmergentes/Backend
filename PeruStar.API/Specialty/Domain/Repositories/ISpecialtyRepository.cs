using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.Specialty.Domain.Repositories;

    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Models.Specialty>> ListAsync();
        Task AddAsync(Models.Specialty specialty);
        Task<Models.Specialty> FindById(long id);
        void Update(Models.Specialty specialty);
        void Remove(Models.Specialty specialty);
    }

