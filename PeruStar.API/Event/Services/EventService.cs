using PeruStar.API.Event.Domain.Models.Status;
using PeruStar.API.Event.Domain.Repositories;
using PeruStar.API.Event.Domain.Services;
using PeruStar.API.Event.Domain.Services.Communication;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Event.Services;

public class EventService: IEventService
{
    private readonly IEventRepository _eventRepository;
    private IUnitOfWork _unitOfWork;

    public EventService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<EventResponse> SaveAsync(long artistId, Domain.Models.Event artistEvent)
    {
        artistEvent.ArtistId = artistId;
        try
        {
            await _eventRepository.AddAsync(artistEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(artistEvent);
        }
        catch (Exception ex)
        {
            return new EventResponse($"An error occurred when saving the event: {ex.Message}");
        }
    }

    public async Task<EventResponse> UpdateAsync(long eventId, long artistId, Domain.Models.Event artistEvent)
    {
        var existingEvent = await _eventRepository.GetByIdAndArtistIdAsync(eventId, artistId);

        if (existingEvent.Equals(null))
            return new EventResponse("Event not found.");

        existingEvent.DateEnd = artistEvent.DateEnd;
        existingEvent.DateStart = artistEvent.DateStart;
        existingEvent.EventTitle = artistEvent.EventTitle;
        existingEvent.EventType = artistEvent.EventType;
        existingEvent.EventAditionalInfo = artistEvent.EventAditionalInfo;

        try
        {
            _eventRepository.Update(existingEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(existingEvent);
        }
        catch (Exception ex)
        {
            return new EventResponse($"An error occurred when updating the event: {ex.Message}");
        }
    }

    public async Task<EventResponse> DeleteAsync(long eventId, long artistId)
    {
        var existingEvent = await _eventRepository.GetByIdAndArtistIdAsync(eventId, artistId);

        if (existingEvent.Equals(null))
            return new EventResponse("Event not found.");

        try
        {
            _eventRepository.Remove(existingEvent);
            await _unitOfWork.CompleteAsync();

            return new EventResponse(existingEvent);
        }
        catch (Exception ex)
        {
            return new EventResponse($"An error occurred when deleting the event: {ex.Message}");
        }
    }

    public async Task<bool> IsSameTitle(string title, long artistId)
    {
        return await _eventRepository.IsSameTitle(title, artistId);
    }
}