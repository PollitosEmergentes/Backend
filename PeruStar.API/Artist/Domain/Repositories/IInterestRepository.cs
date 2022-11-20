using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.Artist.Domain.Repositories;

public interface IInterestRepository
{
    Task<IEnumerable<Interest>> ListAsync();
    Task<IEnumerable<Interest>> ListByHobbyistIdAsync(long hobbyistId);
    Task<Interest> FindByHobbyistIdAndSpecialtyId(long hobbyistId, long specialtyId);
    Task AddAsync(Interest interest);
    void Remove(Interest interest);
    Task AssignInterest(long hobbyistId, long specialtyId);
    Task UnassignInterest(long hobbyistId, long specialtyId);
}