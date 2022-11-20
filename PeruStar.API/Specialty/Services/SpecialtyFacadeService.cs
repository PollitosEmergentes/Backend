using PeruStar.API.Specialty.Domain.Models;
using PeruStar.API.Specialty.Domain.Repositories;
using PeruStar.API.Specialty.Domain.Services.Communication;
using PeruStar.API.Specialty.Interfaces.Internal;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Specialty.Services;
public class SpecialtyFacadeService : ISpecialtyFacade
{
    private readonly ISpecialtyRepository _specialtyRepository;
    private readonly IUnitOfWork _unitOfWork;

    public SpecialtyFacadeService(ISpecialtyRepository specialtyRepository, IUnitOfWork unitOfWork)
    {
        _specialtyRepository = specialtyRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Domain.Models.Specialty>> ListAsync()
    {
        return await _specialtyRepository.ListAsync();
    }

    public async Task<SpecialtyResponse> GetByIdAsync(long id)
    {
        var existingSpecialty = await _specialtyRepository.FindById(id);

        if (existingSpecialty.Equals(null))
            return new SpecialtyResponse("Specialty not found.");

        return new SpecialtyResponse(existingSpecialty);
    }
}


