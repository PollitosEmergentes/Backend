using PeruStar.API.Hobbyist.Domain.Services.Communication;
using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.PeruStar.Domain.Services.Communication;

namespace PeruStar.API.Hobbyist.Domain.Services;

public interface IHobbyistService
{
    Task<HobbyistResponse> SaveAsync(Models.Hobbyist hobbyist);
    Task<HobbyistResponse> UpdateAsync(long id, Models.Hobbyist hobbyist);
    Task<HobbyistResponse> DeleteAsync(long id);
}