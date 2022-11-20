using PeruStar.API.Artist.Domain.Repositories;
using PeruStar.API.Artist.Domain.Services.Communication;
using PeruStar.API.Artist.Interfaces.Internal;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Artist.Services;

public class ArtistFacadeService: IArtistFacade
{
    private readonly IArtistRepository _artistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistFacadeService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
    {
        _artistRepository = artistRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.Artist>> ListAsync()
    {
        return await _artistRepository.ListAsync();
    }

    public Task<IEnumerable<Domain.Models.Artist>> ListByHobbyistIdAsync(int hobbyistId)
    {
        throw new NotImplementedException(); // Falta Folower
    }

    public async Task<ArtistResponse> GetByIdAsync(long id)
    {
        return new ArtistResponse(await _artistRepository.FindById(id));
    }
}