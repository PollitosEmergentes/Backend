using PeruStar.API.Artist.Domain.Models;
using PeruStar.API.Artwork.Domain.Models;
using PeruStar.API.Event.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.Hobbyist.Domain.Models;

public class Hobbyist : Person
{
    public IList<Interest> Interests { get; set; } = new List<Interest>();
    public IList<FavoriteArtwork> FavoriteArtworks { get; set; } = new List<FavoriteArtwork>();
    public IList<Follower.Domain.Models.Follower> Followers { get; set; } = new List<Follower.Domain.Models.Follower>();
    public IList<EventAssistance> Assistance { get; set; } = new List<EventAssistance>();
    public IList<ClaimTicket> ClaimedTickets { get; set; } = new List<ClaimTicket>();
}