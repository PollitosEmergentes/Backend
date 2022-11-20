using PeruStar.API.Event.Domain.Models.Status;
using PeruStar.API.Event.Domain.Services.Communication;

namespace PeruStar.API.Event.Interfaces.Internal;

public interface IEventFacade
{
    Task<EventResponse> GetByIdAndArtistIdAsync(long eventId, long artistId);
    Task<IEnumerable<Domain.Models.Event>> ListAsync();
    Task<IEnumerable<Domain.Models.Event>> ListAsyncByArtistId(long artistId);
    Task<IEnumerable<Domain.Models.Event>> ListAsyncByEventType(ETypeOfEvent eTypeOf);
}