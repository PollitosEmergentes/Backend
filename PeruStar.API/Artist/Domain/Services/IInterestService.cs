using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Artist.Domain.Services.Communication;
using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.Artist.Domain.Services;

public interface IInterestService
{
    Task<IEnumerable<Interest>> ListAsync();
    Task<IEnumerable<Interest>> ListByHobbyistsIdAsync(long hobbyistsId);
    Task<InterestResponse> AssingInterestAsync(long hobbyistsId, long specialtyId);
    Task<InterestResponse> UnassignInterestAsync(long hobbyistsId, long specialtyId);
}