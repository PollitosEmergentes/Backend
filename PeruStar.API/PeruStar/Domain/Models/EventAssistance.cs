namespace PeruStar.API.PeruStar.Domain.Models;

public class EventAssistance
{
    public long Id { get; set; }
    public Event? Event { get; set; }
    public long EventId { get; set; }
    public Hobbyist.Domain.Models.Hobbyist? Hobbyist { get; set; }
    public long HobbyistId { get; set; }
    public Artist.Domain.Models.Artist? Artist { get; set; }
    public long ArtistId { get; set; }
    public DateTime AttendanceDay { get; set; }
}