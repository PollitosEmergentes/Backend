namespace PeruStar.API.Hobbyist.Domain.Repositories;

public interface IHobbyistRepository
{
    Task<IEnumerable<Models.Hobbyist>> ListAsync();
    Task AddAsync(Models.Hobbyist hobbyist);
    Task<Models.Hobbyist> FindById(long id);
    void Update(Models.Hobbyist hobbyist);
    void Remove(Models.Hobbyist hobbyist);
}