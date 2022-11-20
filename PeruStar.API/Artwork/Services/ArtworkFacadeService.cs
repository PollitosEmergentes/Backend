using PeruStar.API.Artist.Domain.Repositories;
using PeruStar.API.Artwork.Domain.Repositories;
using PeruStar.API.Artwork.Domain.Services.Communication;
using PeruStar.API.Artwork.Interfaces.Internal;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Artwork.Services;

public class ArtworkFacadeService: IArtworkFacade
{
    private readonly IArtworkRepository _artworkRepository;
    private readonly IArtistRepository _artistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArtworkFacadeService(IArtworkRepository artworkRepository, IUnitOfWork unitOfWork, IArtistRepository artistRepository)
    {
        _artworkRepository = artworkRepository;
        _unitOfWork = unitOfWork;
        _artistRepository = artistRepository;
    }
    
    public async Task<IEnumerable<Domain.Models.Artwork>> ListAsync()
    {
        return await _artworkRepository.ListAsync();
    }
    
    public async Task<IEnumerable<Domain.Models.Artwork>> ListByArtistIdAsync(long id)
    {
        return await _artworkRepository.ListByArtistIdAsync(id);
    }
    
    public async Task<ArtworkResponse> FindByIdAndArtistIdAsync(long id, long artistId)
    {
        var existingArtwork = await _artworkRepository.FindByIdAndArtistIdAsync(id, artistId);

        if (existingArtwork.Equals(null))
            return new ArtworkResponse("Artwork not found.");

        return new ArtworkResponse(existingArtwork);
    }
    
    public async Task<IEnumerable<Domain.Models.Artwork>> ListByHobbyistAsync(long hobbyistId)
    {
        throw new NotImplementedException(); // Todavia no se implementa
    }
}