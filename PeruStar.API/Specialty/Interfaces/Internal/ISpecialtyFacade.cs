using PeruStar.API.Specialty.Domain.Services.Communication;

namespace PeruStar.API.Specialty.Interfaces.Internal;

public interface ISpecialtyFacade
{
    Task<IEnumerable<Domain.Models.Specialty>> ListAsync();
    Task<SpecialtyResponse> GetByIdAsync(long id);
}