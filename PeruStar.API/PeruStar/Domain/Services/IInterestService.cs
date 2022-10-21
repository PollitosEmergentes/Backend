using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.PeruStar.Domain.Services;

public interface IInterestService
{
    Task<IEnumerable<Interest>> ListAsync();
    Task<IEnumerable<Interest>> ListByHobbyistsIdAsync(long hobbyistsId);
    Task<InterestResponse> AssingInterestAsync(long hobbyistsId, long specialtyId);
    Task<InterestResponse> UnassignInterestAsync(long hobbyistsId, long specialtyId);
}