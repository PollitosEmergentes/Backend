using PeruStar.API.Hobbyist.Domain.Models;
using PeruStar.API.Hobbyist.Domain.Services.Communication;

namespace PeruStar.API.Hobbyist.Interfaces.Internal;

public interface IHobbyistFacade
{
    Task<IEnumerable<Domain.Models.Hobbyist>> ListAsync();
    Task<HobbyistResponse> GetByIdAsync(long id);
}