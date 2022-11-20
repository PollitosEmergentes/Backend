namespace PeruStar.API.Artwork.Domain.Models;

public class FavoriteArtwork
{
    public int Id { get; set; }
    public Hobbyist.Domain.Models.Hobbyist? Hobbyist{ get; set; }
    public long HobbyistId { get; set; }
    public API.Artwork.Domain.Models.Artwork? Artwork { get; set; }
    public long ArtworkId { get; set; }
    public Artist.Domain.Models.Artist? Artist { get; set; }
    public long ArtistId { get; set; }
}