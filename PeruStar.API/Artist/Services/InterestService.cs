using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Artist.Domain.Repositories;
using PeruStar.API.Artist.Domain.Services;
using PeruStar.API.Artist.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Artist.Services;

public class InterestService: IInterestService
{
    private readonly  IInterestRepository _interestRepository;
    private readonly IUnitOfWork _unitOfWork;

    public InterestService(IInterestRepository interestRepository, IUnitOfWork unitOfWork)
    {
        _interestRepository = interestRepository;
        _unitOfWork = unitOfWork;
    }


    public async Task<IEnumerable<Interest>> ListAsync()
    {
        return await _interestRepository.ListAsync();
    }

    public async Task<IEnumerable<Interest>> ListByHobbyistsIdAsync(long hobbyistsId)
    {
        return await _interestRepository.ListByHobbyistIdAsync(hobbyistsId);
    }

    public async Task<InterestResponse> AssingInterestAsync(long hobbyistsId, long specialtyId)
    {
        var existing = await _interestRepository.FindByHobbyistIdAndSpecialtyId(hobbyistsId, specialtyId);
        if (existing.Equals(null))
        {
            return new InterestResponse("Interest already assigned to hobbyist");
        }
        try
        {
            await _interestRepository.AssignInterest(hobbyistsId, specialtyId);
            await _unitOfWork.CompleteAsync();
            Interest hobbyistSpecialty = await _interestRepository.FindByHobbyistIdAndSpecialtyId(hobbyistsId, specialtyId);
            return new InterestResponse(hobbyistSpecialty);
        }
        catch (Exception ex)
        {
            return new InterestResponse($"An error ocurred while assignig Interest: {ex.Message}");
        }
    }

    public async Task<InterestResponse> UnassignInterestAsync(long hobbyistsId, long specialtyId)
    {
        try
        {
            Interest interest = await _interestRepository.FindByHobbyistIdAndSpecialtyId(hobbyistsId, specialtyId);
            if (interest.Equals(null))
                return new InterestResponse("Hobbyist has no interest in Specialty with id: "+ specialtyId);
            await _interestRepository.UnassignInterest(hobbyistsId, specialtyId);
            await _unitOfWork.CompleteAsync();
            return new InterestResponse(interest);
        }
        catch (Exception ex)
        {
            return new InterestResponse($"An error ocurred while unassignig Interest: {ex.Message}");
        }
    }
}