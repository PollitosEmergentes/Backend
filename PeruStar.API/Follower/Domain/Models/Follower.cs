using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.Follower.Domain.Models;

public class Follower
{
    public long Id { get; set; }
    public Hobbyist.Domain.Models.Hobbyist? Hobbyist { get; set; }
    public long HobbyistId { get; set; }
    public Artist.Domain.Models.Artist? Artist { get; set; }
    public long ArtistId { get; set; }
    public long FollowerId { get; set; }
}