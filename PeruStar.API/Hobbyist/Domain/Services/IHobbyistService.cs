using PeruStar.API.Hobbyist.Domain.Services.Communication;

namespace PeruStar.API.Hobbyist.Domain.Services;

public interface IHobbyistService
{
    Task<HobbyistResponse> SaveAsync(Models.Hobbyist hobbyist);
    Task<HobbyistResponse> UpdateAsync(long id, Models.Hobbyist hobbyist);
    Task<HobbyistResponse> DeleteAsync(long id);
}