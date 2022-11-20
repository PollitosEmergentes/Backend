using PeruStar.API.Event.Domain.Models.Status;
using PeruStar.API.Event.Domain.Repositories;
using PeruStar.API.Event.Domain.Services.Communication;
using PeruStar.API.Event.Interfaces.Internal;
using PeruStar.API.Shared.Domain.Repositories;

namespace PeruStar.API.Event.Services;

public class EventFacadeService : IEventFacade
{
    private readonly IEventRepository _eventRepository;
    private readonly IUnitOfWork _unitOfWork;

    public EventFacadeService(IEventRepository eventRepository, IUnitOfWork unitOfWork)
    {
        _eventRepository = eventRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Domain.Models.Event>> ListAsync()
    {
        return await _eventRepository.ListAsync();  
    }

    public async Task<IEnumerable<Domain.Models.Event>> ListAsyncByArtistId(long artistId)
    {
        return await _eventRepository.ListByArtistIdAsync(artistId);
    }

    public async Task<IEnumerable<Domain.Models.Event>> ListAsyncByEventType(ETypeOfEvent eTypeOf)
    {
        return await _eventRepository.ListByEventTypeAsync(eTypeOf);
    }

    public async Task<EventResponse> GetByIdAndArtistIdAsync(long eventId, long artistId)
    {
        var existingEvent = await _eventRepository.GetByIdAndArtistIdAsync(eventId, artistId);

        if (existingEvent.Equals(null))
            return new EventResponse("Event not found.");

        return new EventResponse(existingEvent);
    }
}