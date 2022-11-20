﻿using PeruStar.API.Artist.Domain.Repositories;
using PeruStar.API.Artist.Domain.Services;
using PeruStar.API.Artist.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Artist.Services;

public class ArtistService : IArtistService
{
    private readonly IArtistRepository _artistRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArtistService(IArtistRepository artistRepository, IUnitOfWork unitOfWork)
    {
        _artistRepository = artistRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<ArtistResponse> SaveAsync(Domain.Models.Artist artist)
    {
        try
        {
            await _artistRepository.AddAsync(artist);
            await _unitOfWork.CompleteAsync();

            return new ArtistResponse(artist);
        }
        catch (Exception ex)
        {
            return new ArtistResponse($"An error occurred when saving the artist: {ex.Message}");
        }
    }

    public async Task<ArtistResponse> UpdateAsync(long id, Domain.Models.Artist artist)
    {
        var existingArtist = await _artistRepository.FindById(id);

        if (existingArtist.Equals(null))
            return new ArtistResponse("Artist not found.");

        existingArtist.BrandName = artist.BrandName;
        existingArtist.Description = artist.Description;
        existingArtist.Phrase = artist.Phrase;
        existingArtist.Firstname = artist.Firstname;
        existingArtist.Lastname = artist.Lastname;

        try
        {
            _artistRepository.Update(existingArtist);
            await _unitOfWork.CompleteAsync();

            return new ArtistResponse(existingArtist);
        }
        catch (Exception ex)
        {
            return new ArtistResponse($"An error occurred when updating the artist: {ex.Message}");
        }
    }

    public async Task<ArtistResponse> DeleteAsync(long id)
    {
        var existingArtist = await _artistRepository.FindById(id);
        if (existingArtist.Equals(null))
            return new ArtistResponse("Artist not found.");
        
        try
        {
            _artistRepository.Remove(existingArtist);
            await _unitOfWork.CompleteAsync();

            return new ArtistResponse(existingArtist);
        }
        catch (Exception ex)
        {
            return new ArtistResponse($"An error occurred when deleting the artist: {ex.Message}");
        }
    }

    public async Task<bool> IsSameBrandingName(string brandingName)
    {
        return await _artistRepository.IsSameBrandingName(brandingName);
    }
}