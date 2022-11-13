namespace PeruStar.API.PeruStar.Domain.Models;

public class Follower
{
    public long Id { get; set; }
    public Hobbyist? Hobbyist { get; set; }
    public long HobbyistId { get; set; }
    public Artist.Domain.Models.Artist? Artist { get; set; }
    public long ArtistId { get; set; }
    public long FollowerId { get; set; }
}