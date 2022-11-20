using PeruStar.API.Event.Domain.Models;
using PeruStar.API.PeruStar.Domain.Models;

namespace PeruStar.API.Artist.Domain.Models;

public class Artist : Person
{
    public string? BrandName { get; set; }
    public string? Description { get; set; }
    public string? Phrase { get; set; }
    public IList<Artwork.Domain.Models.Artwork> Artworks { get; set; } = new List<Artwork.Domain.Models.Artwork>();
    public IList<Event.Domain.Models.Event> Events { get; set; } = new List<Event.Domain.Models.Event>();
    public IList<Follower> Followers { get; set; } = new List<Follower>();
    public IList<FavoriteArtwork> FavoriteArtworks { get; set; } = new List<FavoriteArtwork>();
    public IList<EventAssistance> EventAssistances { get; set; } = new List<EventAssistance>();
    public IList<ClaimTicket> ClaimTickets { get; set; } = new List<ClaimTicket>();
    public Specialty? Specialty { get; set; }
    public IList<string> SocialMediaLink { get; set; } = new List<string>();
    public long SpecialtyId { get; set; }
}