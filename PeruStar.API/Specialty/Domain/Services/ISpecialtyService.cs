using PeruStar.API.PeruStar.Domain.Models;
using PeruStar.API.Specialty.Domain.Services.Communication;

namespace PeruStar.API.Specialty.Domain.Services;
public interface ISpecialtyService
{
    Task<SpecialtyResponse> SaveAsync(Models.Specialty specialty);
    Task<SpecialtyResponse> UpdateAsync(long id, Models.Specialty specialty);
    Task<SpecialtyResponse> DeleteAsync(long id);
}


