using PeruStar.API.Event.Domain.Models.Status;

namespace PeruStar.API.Event.Domain.Repositories;

public interface IEventRepository
{
    Task<IEnumerable<Models.Event>> ListAsync();
    Task<IEnumerable<Models.Event>> ListByArtistIdAsync(long artistId);
    Task<IEnumerable<Models.Event>> ListByEventTypeAsync(ETypeOfEvent typeOfEvent);
    Task<Models.Event> GetByIdAndArtistIdAsync(long eventId, long artistId);
    Task AddAsync(Models.Event artisticEvent);
    Task<Models.Event> FindById(long id);
    void Update(Models.Event artisticEvent);
    void Remove(Models.Event artisticEvent);
    Task<bool> IsSameTitle(string title, long artistId);
}