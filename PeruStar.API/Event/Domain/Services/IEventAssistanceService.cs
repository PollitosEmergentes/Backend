using PeruStar.API.Event.Domain.Models;
using PeruStar.API.Event.Domain.Services.Communication;

namespace PeruStar.API.Event.Domain.Services;

public interface IEventAssistanceService
{
    Task<IEnumerable<EventAssistance>> ListAsync();
    Task<IEnumerable<EventAssistance>> ListAsyncByHobbyistId(long hobbyistId);
    Task<EventAssistanceResponse> AssignEventAssistanceAsync(long hobbyistId, long eventId, DateTime attendance);
    Task<EventAssistanceResponse> UnassignEventAssistanceAsync(long hobbyistId, long eventId);
}