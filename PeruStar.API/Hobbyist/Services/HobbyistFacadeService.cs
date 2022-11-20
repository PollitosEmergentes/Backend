using PeruStar.API.Hobbyist.Domain.Models;
using PeruStar.API.Hobbyist.Domain.Repositories;
using PeruStar.API.Hobbyist.Domain.Services.Communication;
using PeruStar.API.Hobbyist.Interfaces.Internal;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Hobbyist.Services;
public class HobbyistFacadeService : IHobbyistFacade
{
    private readonly IHobbyistRepository _hobbyistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public HobbyistFacadeService(IHobbyistRepository hobbyistRepository, IUnitOfWork unitOfWork)
    {
        _hobbyistRepository = hobbyistRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<Domain.Models.Hobbyist>> ListAsync()
    {
        return await _hobbyistRepository.ListAsync();
    }

    public async Task<HobbyistResponse> GetByIdAsync(long id)
    {
        return new HobbyistResponse(await _hobbyistRepository.FindById(id));
    }
}


