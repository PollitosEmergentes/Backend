namespace PeruStar.API.Specialty.Domain.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<IEnumerable<Specialty.Domain.Models.Specialty>> ListAsync();
        Task AddAsync(Specialty.Domain.Models.Specialty specialty);
        Task<Specialty.Domain.Models.Specialty> FindById(long id);
        void Update(Specialty.Domain.Models.Specialty specialty);
        void Remove(Specialty.Domain.Models.Specialty specialty);
    }
}
