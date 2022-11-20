using PeruStar.API.Event.Domain.Services.Communication;

namespace PeruStar.API.Event.Domain.Services;

public interface IEventService
{
    Task<EventResponse> SaveAsync(long artistId, Models.Event artistEvent);
    Task<EventResponse> UpdateAsync(long eventId, long artistId, Models.Event artistEvent);
    Task<EventResponse> DeleteAsync(long eventId, long artistId);
    Task<bool> IsSameTitle(string title, long artistId);
}